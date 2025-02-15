export async function prepare(context) {
    context.addReadFile('apps/be/scripts/add_migration.sh');
}

export async function prompt(context) {
    const {description} = await context.inquirerPrompt({
        type: 'editor',
        name: 'description',
        message: 'Describe the entity (properties, relationships, etc):',
    });

    return {
        prompt: `Create an entity based on this description:
${description}

Requirements:
1. Follow the example files structure
2. Use proper C# conventions and best practices
3. Add appropriate indexes in EntityTypeConfiguration
4. Add proper navigation properties if needed
5. Register the entity in DataContext

The entity '${context.vars['ENTITY_NAME']}' should be created.`
    };
}
