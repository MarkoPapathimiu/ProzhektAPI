using Microsoft.EntityFrameworkCore;
using ProzhektAPI.Data.Models;

namespace ProzhektAPI.Data.Seed
{
    public static class WorkoutsRecipesSeed
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Workout>().HasData(
                new Workout
                {
                    Id = 1,
                    Name = "Plank",
                    Description = "Hold your body in a straight line off the ground."
                },
               new Workout
               {
                   Id = 2,
                   Name = "Squat",
                   Description = "Works glutes, quads, and hamstrings; lower your hips down and back like you're sitting in a chair, then push through your heels to stand.  \r\n"
               },
               new Workout
               {
                   Id = 3,
                   Name = "Single Leg Bridge",
                   Description = "Strengthens glutes and hamstrings; lie on your back, lift one leg, and push through the other heel to raise your hips.  \r\n"
               },
               new Workout
               {
                   Id = 4,
                   Name = "Crunch",
                   Description = "Focuses on upper abs; lie on your back, knees bent, and lift your shoulders off the floor using your core.  \r\n"
               },
               new Workout
               {
                   Id = 5,
                   Name = "Flutter Kicks",
                   Description = "Hits lower abs and hip flexors; lie on your back and rapidly alternate kicking your straight legs up and down a few inches off the ground."
               },
               new Workout
               {
                   Id = 6,
                   Name = "Bird Leg",
                   Description = "Engages core and back; on all fours, extend opposite arm and leg straight, then switch sides.  "
               },
               new Workout
               {
                   Id = 7,
                   Name = "Cat-Cow",
                   Description = "Loosens spine and works core; alternate between arching your back up (cat) and dipping it down (cow) while on all fours."
               },
               new Workout
               {
                   Id = 8,
                   Name = "Star Jumps",
                   Description = "Boosts cardio and works full body; squat slightly then explode upward, spreading arms and legs like a star mid-air.  \r\n"
               },
               new Workout
               {
                   Id = 9,
                   Name = "Jumping Lunges",
                   Description = "Builds quads, glutes, and calves; jump to switch legs in a lunge position, landing softly each time.  \r\n"
               },
               new Workout
               {
                   Id = 10,
                   Name = "Fire Hydrant",
                   Description = "Targets glutes and hips; on hands and knees, lift one knee out to the side without tilting your torso.  \r\n"
               },
               new Workout
               {
                   Id = 11,
                   Name = "Russian Twists",
                   Description = "Works obliques and abs; sit with feet up, lean back slightly, and twist your torso side to side.  \r\n"
               },
               new Workout
               {
                   Id = 12,
                   Name = "Sit Up",
                   Description = "Strengthens abs and hip flexors; lie on your back and use your core to lift your upper body to a seated position."
               }

            );

            modelBuilder.Entity<Recipe>().HasData(
                 new Recipe
                 {
                     Id = 1,
                     Name = "Avocado toast with poached egg",
                     Description = "Toast the whole grain bread. Mash avocado and spread it over the toast."
                 },
                 new Recipe
                 {
                     Id = 2,
                     Name = "Yogurt with Blueberries & Honey",
                     Description = "Scoop 1 cup of Greek yogurt into a bowl. Top with 1/2 cup of blueberries and drizzle with 1-2 tbsp honey."
                 },
                 new Recipe
                 {
                     Id = 3,
                     Name = "Egg-Avocado Breakfast Sandwich",
                     Description = "Spread mayonnaise on 1 bagel thin half. Top with cheese, avocado, sprouts, fried egg and onion."
                 },
                 new Recipe
                 {
                     Id = 4,
                     Name = "Oats with chia seeds and almond butter",
                     Description = "Cook oats with almond milk until creamy. Stir in chia seeds and almond butter."
                 },
                 new Recipe
                 {
                     Id = 5,
                     Name = "Berry-Almond Smoothie Bowl",
                     Description = "Blend raspberries, banana, almond milk, 3 tbsp almonds, cinnamon, cardamom and vanilla. Blend until smooth and creamy."
                 },
                 new Recipe
                 {
                     Id = 6,
                     Name = "Savory Oatmeal with Cheddar, Collards & Eggs",
                     Description = "Cook shallot in 1 tbsp oil, add oats, then water, salt, and pepper. Sauté collards in 1 tbsp oil, with water, salt, and pepper for 5-7 minutes."
                 },
                 new Recipe
                 {
                     Id = 7,
                     Name = "Vegan Smoothie Bowl",
                     Description = "Combine banana, berries and soymilk (or almond milk) in a blender unit smooth. Pour the smoothie into a bowl and top with pineapple, kiwi, almonds, coconut and chia seeds."
                 },
                 new Recipe
                 {
                     Id = 8,
                     Name = "Apple Ricotta Pancakes",
                     Description = "In a medium mixing bowl, combine the flour, baking powder, ground cinnamon, baking soda. In another bowl, whisk egg, buttermilk, ricotta, 1 tbsp sugar, and vanilla."
                 },
                 new Recipe
                 {
                     Id = 9,
                     Name = "Tuna Salad with Mixed Greens",
                     Description = "Toss lettuce, vegetables, oil, vinegar, and herbs in a large salad bowl. Mix ingredients for tuna salad in another medium-sized mixing bowl."
                 },
                 new Recipe
                 {
                     Id = 10,
                     Name = "Sweet Potato and Black Bean bowl",
                     Description = "Dice sweet potatoes and vegetables evenly for even cooking. Use fire-roasted tomatoes for extra flavor."
                 },
                 new Recipe
                 {
                     Id = 11,
                     Name = "Salmon with Roasted Vegetables",
                     Description = "Toss zucchini, bell pepper, onion, and cherry tomatoes with olive oil, oregano, salt, and pepper. Grill or bake the salmon fillet until cooked."
                 },
                 new Recipe
                 {
                     Id = 12,
                     Name = "Chicken & Broccoli Casserole",
                     Description = "Cook chicken and onion in oil until the chicken is no longer pink. Stir in flour, add milk, and bring to a boil."
                 },
                 new Recipe
                 {
                     Id = 13,
                     Name = "Chicken & Broccoli Salad",
                     Description = "In a large skillet over medium heat, cook chopped bacon until crisp (about 6 minutes). Sprinkle chicken tenders with ¼ tsp salt and ¼ tsp pepper."
                 },
                 new Recipe
                 {
                     Id = 14,
                     Name = "Salad with Quinoa,Chicken & Berries",
                     Description = "Layer spinach, quinoa, and cooked chicken in containers;top with berries, cheese, and almonds. Chill salads until ready to serve."
                 },
                 new Recipe
                 {
                     Id = 15,
                     Name = "Quinoa, Avocado & Chickpea Salad",
                     Description = "Boil, simmer until liquid is absorbed, fluff with a fork, and cool. Mash garlic with salt into a paste; whisk with lemon zest, juice, oil, and pepper."
                 },
                 new Recipe
                 {
                     Id = 16,
                     Name = "Veggie Wraps",
                     Description = "cook sliced zucchini, bell pepper, onion, ½ tsp oregano, and a pinch of salt until soft. Spread hummus on wraps, add spinach, sautéed veggies, feta, and olives."
                 },
                 new Recipe
                 {
                     Id = 17,
                     Name = "Bean & Barley Soup",
                     Description = "Cook onion, fennel, garlic, and basil in oil until tender (6-8 minutes). Stir in mashed and whole beans, tomatoes, broth, and barley; bring to a boil."
                 },
                 new Recipe
                 {
                     Id = 18,
                     Name = "Tomato Soup with Beans & Greens",
                     Description = "Heat soup in a saucepan according to package directions; simmer on low. Heat oil in a skillet, cook kale until wilted (1-2 minutes), then add garlic and crushed red pepper, cooking for 30 seconds."
                 },
                 new Recipe
                 {
                     Id = 19,
                     Name = "Steak Burritos",
                     Description = "Simmer salsa, water, and rice for 5 minutes, then add beans and cook. until rice is tender."
                 },
                 new Recipe
                 {
                     Id = 20,
                     Name = "Easy Pea & Spinach Carbonara",
                     Description = "Heat oil in a skillet, add breadcrumbs and garlic; cook, stirring, until toasted. Add beans and cook until rice is tender, about 5 more minutes."
                 },
                 new Recipe
                 {
                     Id = 21,
                     Name = "Spaghetti with Lemon-Spinach Sauce",
                     Description = "Boil water, cook pasta per package instructions, reserve ½ cup cooking water, and drain. Blend spinach, basil, oil, lemon juice, garlic, and salt until smooth."
                 },
                 new Recipe
                 {
                     Id = 22,
                     Name = "Crispy Salmon Rice Bowl",
                     Description = "Toss with sesame oil, roast at 450°F for 6 mins. Drizzle with teriyaki glaze, broil until crispy."
                 },
                 new Recipe
                 {
                     Id = 23,
                     Name = "One-Skillet Garlicky Salmon & Broccoli",
                     Description = "Sauté with half the garlic, salt, and red pepper until just cooked (4–5 mins); transfer to a plate. In the same skillet, add broccoli, bell peppers, water, remaining garlic, and salt; cover and cook until tender-crisp."
                 },
                 new Recipe
                 {
                     Id = 24,
                     Name = "Chicken Tortellini Soup",
                     Description = "Cook onion, carrots, celery, and garlic in butter until soft; add tarragon, seasoning, pepper. Add broth, bring to a boil, stir in tortellini, and cook covered until al dente (about 5 mins)."
                 }

            );
        }
    }
}
