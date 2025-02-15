import path from 'path';

let queries = [
    'CustomQueryEndpoint',
    'DetailEndpoint',
    'ListEndpoint',
    'ListEnumEndpoint',
];

let listQueries = [
    'ListEndpoint',
    'ListEnumEndpoint',
];

let commands = [
    'CreateEndpoint',
    'CustomCommandEndpoint',
    'DeleteEndpoint',
    'UpdateEndpoint'
];

let controllerActions = [
    ...commands,
    ...queries
];

export async function prepare(context) {
    if (context.vars.ENTITIES) {
        context.addReadFile('apps/be/src/DAL/Core.Data/Entities/*.cs');
    }
    
    if (context.vars['PIECE_NAME'].includes('Endpoint')) {
        context.vars['PIECE_ENDPOINT_NAME'] = context.vars['PIECE_NAME'].replace('Endpoint', '');
    }

    if (commands.includes(context.vars['PIECE_NAME']) ) {
        context.addReadFile('puzzle/common/custom/ExampleValidator.cs');
        context.addWriteFile('apps/be/src/BL/Core.Common/Errors/ErrorCodes.cs');
    }

    if (listQueries.includes(context.vars['PIECE_NAME'])) {
        context.addReadFile('puzzle/common/custom/ExampleTextSearchProvider.cs');
    }
    
    if (controllerActions.includes(context.vars['PIECE_NAME'])) {
        context.addReadFile('puzzle/common/custom/ExampleController.cs');
        context.addWriteFile('apps/be/src/Core.Gateway/Controllers/V1/{MODULE_NAME}/{PLURAL_ENTITY_NAME}Controller.cs');
    }

    context.addReadFile('apps/be/src/DAL/Core.Data/Entities/User.cs');
}

export async function setup(context) {
    if (context.vars.ENTITIES) {
        context.addReadFile('apps/be/src/DAL/Core.Data/Entities/*.cs');
    }

    if (commands.includes(context.vars['PIECE_NAME'])) {
        const validatorPath = nextTo(context.writeFiles, 'Command.cs', 'Validator');
        context.addWriteFile(validatorPath);
    }

    if (listQueries.includes(context.vars['PIECE_NAME'])) {
        const textSearchPath = nextToWithCustomName(context.writeFiles, 'Query.cs', '{ENTITY_NAME}TextSearchProvider.cs');
        context.addWriteFile(textSearchPath);
    }
}

export async function prompt(context) {
    if (context.vars['ENTERED_CUSTOM_PROMPT']) {
        return context.vars['ENTERED_CUSTOM_PROMPT'];
    }
    
    if (context.vars['CUSTOM-PROMPT']) {
        const {userPrompt} = await context.inquirerPrompt({
            type: 'editor',
            name: 'userPrompt',
            default: 'ENTERED_CUSTOM_PROMPT' in context.defaultVars ? context.defaultVars['ENTERED_CUSTOM_PROMPT'] : undefined,
            message: `Enter custom instructions.`,
        });
        
        // no need to enter the prompt again for next action
        context.vars['ENTERED_CUSTOM_PROMPT'] = userPrompt;

        return userPrompt;
    }
    
    return null; 
}

function nextTo(files, targetFileExpression, appendFileName) {
    // Find the target file in the list of files
    const targetFile = files.find(file => file.includes(targetFileExpression));
    
    if (!targetFile) {
        return null;
    }

    // Get the directory and base name of the target file
    const targetDir = path.dirname(targetFile);
    const targetBase = path.basename(targetFile, path.extname(targetFile));

    // Construct the new file path with the appended file name
    const newFileName = `${targetBase}${appendFileName}${path.extname(targetFile)}`;
    
    return path.join(targetDir, newFileName);
}

function nextToWithCustomName(files, targetFileExpression, customNamePattern) {
    const targetFile = files.find(file => file.includes(targetFileExpression));
    
    if (!targetFile) {
        return null;
    }

    // Get the parent directory of the target file's directory
    const targetDir = path.dirname(path.dirname(targetFile));
    
    return path.join(targetDir, customNamePattern);
}
