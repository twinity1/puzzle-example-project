export async function prepare(context) {
    context.addReadFile('apps/be/src/DAL/Core.Data/Entities/{ENTITY_NAME}.cs');
    context.addReadFile('apps/be/src/DAL/Core.Data/Context/ICoreDataContext.cs');
    context.addReadFile('apps/be/src/DAL/Core.Data/Seeds/Entities/*.cs');
}

export async function prompt(context) {

    const {userPrompt} = await context.inquirerPrompt({
        type: 'input',
        name: 'userPrompt',
        message: `Enter instructions for seed (how many examples, or list of examples, etc.):`,
    });

    return {
        prompt: `Implement the operation: ${context.vars['PIECE_NAME']} for entity ${context.vars['ENTITY_NAME']}.
        Replace "Example" with the name of the entity.
        Register the seed within method private static void AddSeeds(IServiceCollection services). 
        ${userPrompt}`
    };
}
