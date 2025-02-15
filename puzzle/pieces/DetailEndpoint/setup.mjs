export async function prepare(context) {
    context.addReadFile('apps/be/src/DAL/Core.Data/Entities/{ENTITY_NAME}.cs');
}

export async function prompt(context) {
    return {
        prompt: `Implement the operation: ${context.vars['PIECE_NAME']} for entity ${context.vars['ENTITY_NAME']} in module ${context.vars['MODULE_NAME']}.
        Replace "Example" with the name of the entity. 
    Reference the action ${context.vars['PIECE_NAME']} operation like in attached example files.
    Add endpoint to a controller. Be precise to the example files as you can.`
    };
}
