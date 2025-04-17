using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProzhektAPI.Migrations
{
    /// <inheritdoc />
    public partial class NewData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Bmi",
                table: "Users",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Toast the whole grain bread. Mash avocado and spread it over the toast.", "Avocado toast with poached egg" },
                    { 2, "Scoop 1 cup of Greek yogurt into a bowl. Top with 1/2 cup of blueberries and drizzle with 1-2 tbsp honey.", "Yogurt with Blueberries & Honey" },
                    { 3, "Spread mayonnaise on 1 bagel thin half. Top with cheese, avocado, sprouts, fried egg and onion.", "Egg-Avocado Breakfast Sandwich" },
                    { 4, "Cook oats with almond milk until creamy. Stir in chia seeds and almond butter.", "Oats with chia seeds and almond butter" },
                    { 5, "Blend raspberries, banana, almond milk, 3 tbsp almonds, cinnamon, cardamom and vanilla. Blend until smooth and creamy.", "Berry-Almond Smoothie Bowl" },
                    { 6, "Cook shallot in 1 tbsp oil, add oats, then water, salt, and pepper. Sauté collards in 1 tbsp oil, with water, salt, and pepper for 5-7 minutes.", "Savory Oatmeal with Cheddar, Collards & Eggs" },
                    { 7, "Combine banana, berries and soymilk (or almond milk) in a blender unit smooth. Pour the smoothie into a bowl and top with pineapple, kiwi, almonds, coconut and chia seeds.", "Vegan Smoothie Bowl" },
                    { 8, "In a medium mixing bowl, combine the flour, baking powder, ground cinnamon, baking soda. In another bowl, whisk egg, buttermilk, ricotta, 1 tbsp sugar, and vanilla.", "Apple Ricotta Pancakes" },
                    { 9, "Toss lettuce, vegetables, oil, vinegar, and herbs in a large salad bowl. Mix ingredients for tuna salad in another medium-sized mixing bowl.", "Tuna Salad with Mixed Greens" },
                    { 10, "Dice sweet potatoes and vegetables evenly for even cooking. Use fire-roasted tomatoes for extra flavor.", "Sweet Potato and Black Bean bowl" },
                    { 11, "Toss zucchini, bell pepper, onion, and cherry tomatoes with olive oil, oregano, salt, and pepper. Grill or bake the salmon fillet until cooked.", "Salmon with Roasted Vegetables" },
                    { 12, "Cook chicken and onion in oil until the chicken is no longer pink. Stir in flour, add milk, and bring to a boil.", "Chicken & Broccoli Casserole" },
                    { 13, "In a large skillet over medium heat, cook chopped bacon until crisp (about 6 minutes). Sprinkle chicken tenders with ¼ tsp salt and ¼ tsp pepper.", "Chicken & Broccoli Salad" },
                    { 14, "Layer spinach, quinoa, and cooked chicken in containers;top with berries, cheese, and almonds. Chill salads until ready to serve.", "Salad with Quinoa,Chicken & Berries" },
                    { 15, "Boil, simmer until liquid is absorbed, fluff with a fork, and cool. Mash garlic with salt into a paste; whisk with lemon zest, juice, oil, and pepper.", "Quinoa, Avocado & Chickpea Salad" },
                    { 16, "cook sliced zucchini, bell pepper, onion, ½ tsp oregano, and a pinch of salt until soft. Spread hummus on wraps, add spinach, sautéed veggies, feta, and olives.", "Veggie Wraps" },
                    { 17, "Cook onion, fennel, garlic, and basil in oil until tender (6-8 minutes). Stir in mashed and whole beans, tomatoes, broth, and barley; bring to a boil.", "Bean & Barley Soup" },
                    { 18, "Heat soup in a saucepan according to package directions; simmer on low. Heat oil in a skillet, cook kale until wilted (1-2 minutes), then add garlic and crushed red pepper, cooking for 30 seconds.", "Tomato Soup with Beans & Greens" },
                    { 19, "Simmer salsa, water, and rice for 5 minutes, then add beans and cook. until rice is tender.", "Steak Burritos" },
                    { 20, "Heat oil in a skillet, add breadcrumbs and garlic; cook, stirring, until toasted. Add beans and cook until rice is tender, about 5 more minutes.", "Easy Pea & Spinach Carbonara" },
                    { 21, "Boil water, cook pasta per package instructions, reserve ½ cup cooking water, and drain. Blend spinach, basil, oil, lemon juice, garlic, and salt until smooth.", "Spaghetti with Lemon-Spinach Sauce" },
                    { 22, "Toss with sesame oil, roast at 450°F for 6 mins. Drizzle with teriyaki glaze, broil until crispy.", "Crispy Salmon Rice Bowl" },
                    { 23, "Sauté with half the garlic, salt, and red pepper until just cooked (4–5 mins); transfer to a plate. In the same skillet, add broccoli, bell peppers, water, remaining garlic, and salt; cover and cook until tender-crisp.", "One-Skillet Garlicky Salmon & Broccoli" },
                    { 24, "Cook onion, carrots, celery, and garlic in butter until soft; add tarragon, seasoning, pepper. Add broth, bring to a boil, stir in tortellini, and cook covered until al dente (about 5 mins).", "Chicken Tortellini Soup" }
                });

            migrationBuilder.InsertData(
                table: "Workouts",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Hold your body in a straight line off the ground.", "Plank" },
                    { 2, "Works glutes, quads, and hamstrings; lower your hips down and back like you're sitting in a chair, then push through your heels to stand.  \r\n", "Squat" },
                    { 3, "Strengthens glutes and hamstrings; lie on your back, lift one leg, and push through the other heel to raise your hips.  \r\n", "Single Leg Bridge" },
                    { 4, "Focuses on upper abs; lie on your back, knees bent, and lift your shoulders off the floor using your core.  \r\n", "Crunch" },
                    { 5, "Hits lower abs and hip flexors; lie on your back and rapidly alternate kicking your straight legs up and down a few inches off the ground.", "Flutter Kicks" },
                    { 6, "Engages core and back; on all fours, extend opposite arm and leg straight, then switch sides.  ", "Bird Leg" },
                    { 7, "Loosens spine and works core; alternate between arching your back up (cat) and dipping it down (cow) while on all fours.", "Cat-Cow" },
                    { 8, "Boosts cardio and works full body; squat slightly then explode upward, spreading arms and legs like a star mid-air.  \r\n", "Star Jumps" },
                    { 9, "Builds quads, glutes, and calves; jump to switch legs in a lunge position, landing softly each time.  \r\n", "Jumping Lunges" },
                    { 10, "Targets glutes and hips; on hands and knees, lift one knee out to the side without tilting your torso.  \r\n", "Fire Hydrant" },
                    { 11, "Works obliques and abs; sit with feet up, lean back slightly, and twist your torso side to side.  \r\n", "Russian Twists" },
                    { 12, "Strengthens abs and hip flexors; lie on your back and use your core to lift your upper body to a seated position.", "Sit Up" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.AlterColumn<double>(
                name: "Bmi",
                table: "Users",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");
        }
    }
}
