export async function prepare(context) {
    context.addReadFile('apps/be/src/DAL/Core.Data/Entities/{ENTITY_NAME}.cs');
}

export async function prompt(context) {
    const {userPrompt} = await context.inquirerPrompt({
        type: 'input',
        name: 'userPrompt',
        message: `Enter instructions for the custom action (what should be implemented?):`,
    });
    
    return {
        prompt: `Implement the operation: ${context.vars['CUSTOM_ACTION_NAME']} in module ${context.vars['MODULE_NAME']}.
        Replace "Example" with the name of the entity. And ActionName with the name of the action.
    Add endpoint to a controller (make sure to fill operation id). ${userPrompt}`
    };
}
