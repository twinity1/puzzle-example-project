export async function prepare(context) {
    context.addReadFile('apps/be/src/BL/Core.{MODULE_NAME}/NotificationHandlers/{PLURAL_ENTITY_NAME}/**/*.cs');
    context.addReadFile('apps/be/src/BL/Core.{MODULE_NAME}/UseCases/{PLURAL_ENTITY_NAME}/**/*.cs');
    context.addReadFile('apps/be/src/Core.Gateway/Controllers/V1/{MODULE_NAME}/{PLURAL_ENTITY_NAME}Controller.cs');
    context.addReadFile('apps/be/tests/Core.IntegrationTests/Modules/{MODULE_NAME}/{PLURAL_ENTITY_NAME}/**/*.cs');
    context.addReadFile('apps/be/tests/Core.IntegrationTests/Modules/{MODULE_NAME}/{PLURAL_ENTITY_NAME}/**/*.txt');
    context.addReadFile('apps/be/tests/Core.IntegrationTests/Modules/{MODULE_NAME}/{PLURAL_ENTITY_NAME}/**/*.json');
    context.addReadFile('apps/be/docs/modules/Global/QueryFilters.md');
}

export async function prompt(context) {

    const {userPrompt} = await context.inquirerPrompt({
        type: 'input',
        name: 'userPrompt',
        message: `Enter instructions for the docs (what should be included in the documentation?):`,
    });

    return {
        prompt: `Implement docs for endpoints ${context.vars['PLURAL_ENTITY_NAME']} in module ${context.vars['MODULE_NAME']}}.
        - Stick to the template
        - Provide a description of the endpoint (for business people, average project manager must understand what is going on)
        - List all constraints (what conditions are checked in the endpoint, for each endpoint separately)
        - List all possible errors/responses
        - Do not mention any .NET internal logic
        - Do not mention any obvious things - like Guid type must be valid Guid
        - Endpoints are always kebab-use
        - Make sure to write full example response from the examples (if available)
        
        Here are some custom user instructions:
        ${userPrompt}`
    };
}
