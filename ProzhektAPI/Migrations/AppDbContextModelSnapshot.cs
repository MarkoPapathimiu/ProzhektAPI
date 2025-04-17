﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProzhektAPI.Data;

#nullable disable

namespace ProzhektAPI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ProzhektAPI.Data.Models.FavoriteRecipe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("RecipeId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RecipeId");

                    b.HasIndex("UserId");

                    b.ToTable("FavoriteRecipes");
                });

            modelBuilder.Entity("ProzhektAPI.Data.Models.FavoriteWorkout", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("WorkoutId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.HasIndex("WorkoutId");

                    b.ToTable("FavoriteWorkouts");
                });

            modelBuilder.Entity("ProzhektAPI.Data.Models.Recipe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Recipes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Toast the whole grain bread. Mash avocado and spread it over the toast.",
                            Name = "Avocado toast with poached egg"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Scoop 1 cup of Greek yogurt into a bowl. Top with 1/2 cup of blueberries and drizzle with 1-2 tbsp honey.",
                            Name = "Yogurt with Blueberries & Honey"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Spread mayonnaise on 1 bagel thin half. Top with cheese, avocado, sprouts, fried egg and onion.",
                            Name = "Egg-Avocado Breakfast Sandwich"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Cook oats with almond milk until creamy. Stir in chia seeds and almond butter.",
                            Name = "Oats with chia seeds and almond butter"
                        },
                        new
                        {
                            Id = 5,
                            Description = "Blend raspberries, banana, almond milk, 3 tbsp almonds, cinnamon, cardamom and vanilla. Blend until smooth and creamy.",
                            Name = "Berry-Almond Smoothie Bowl"
                        },
                        new
                        {
                            Id = 6,
                            Description = "Cook shallot in 1 tbsp oil, add oats, then water, salt, and pepper. Sauté collards in 1 tbsp oil, with water, salt, and pepper for 5-7 minutes.",
                            Name = "Savory Oatmeal with Cheddar, Collards & Eggs"
                        },
                        new
                        {
                            Id = 7,
                            Description = "Combine banana, berries and soymilk (or almond milk) in a blender unit smooth. Pour the smoothie into a bowl and top with pineapple, kiwi, almonds, coconut and chia seeds.",
                            Name = "Vegan Smoothie Bowl"
                        },
                        new
                        {
                            Id = 8,
                            Description = "In a medium mixing bowl, combine the flour, baking powder, ground cinnamon, baking soda. In another bowl, whisk egg, buttermilk, ricotta, 1 tbsp sugar, and vanilla.",
                            Name = "Apple Ricotta Pancakes"
                        },
                        new
                        {
                            Id = 9,
                            Description = "Toss lettuce, vegetables, oil, vinegar, and herbs in a large salad bowl. Mix ingredients for tuna salad in another medium-sized mixing bowl.",
                            Name = "Tuna Salad with Mixed Greens"
                        },
                        new
                        {
                            Id = 10,
                            Description = "Dice sweet potatoes and vegetables evenly for even cooking. Use fire-roasted tomatoes for extra flavor.",
                            Name = "Sweet Potato and Black Bean bowl"
                        },
                        new
                        {
                            Id = 11,
                            Description = "Toss zucchini, bell pepper, onion, and cherry tomatoes with olive oil, oregano, salt, and pepper. Grill or bake the salmon fillet until cooked.",
                            Name = "Salmon with Roasted Vegetables"
                        },
                        new
                        {
                            Id = 12,
                            Description = "Cook chicken and onion in oil until the chicken is no longer pink. Stir in flour, add milk, and bring to a boil.",
                            Name = "Chicken & Broccoli Casserole"
                        },
                        new
                        {
                            Id = 13,
                            Description = "In a large skillet over medium heat, cook chopped bacon until crisp (about 6 minutes). Sprinkle chicken tenders with ¼ tsp salt and ¼ tsp pepper.",
                            Name = "Chicken & Broccoli Salad"
                        },
                        new
                        {
                            Id = 14,
                            Description = "Layer spinach, quinoa, and cooked chicken in containers;top with berries, cheese, and almonds. Chill salads until ready to serve.",
                            Name = "Salad with Quinoa,Chicken & Berries"
                        },
                        new
                        {
                            Id = 15,
                            Description = "Boil, simmer until liquid is absorbed, fluff with a fork, and cool. Mash garlic with salt into a paste; whisk with lemon zest, juice, oil, and pepper.",
                            Name = "Quinoa, Avocado & Chickpea Salad"
                        },
                        new
                        {
                            Id = 16,
                            Description = "cook sliced zucchini, bell pepper, onion, ½ tsp oregano, and a pinch of salt until soft. Spread hummus on wraps, add spinach, sautéed veggies, feta, and olives.",
                            Name = "Veggie Wraps"
                        },
                        new
                        {
                            Id = 17,
                            Description = "Cook onion, fennel, garlic, and basil in oil until tender (6-8 minutes). Stir in mashed and whole beans, tomatoes, broth, and barley; bring to a boil.",
                            Name = "Bean & Barley Soup"
                        },
                        new
                        {
                            Id = 18,
                            Description = "Heat soup in a saucepan according to package directions; simmer on low. Heat oil in a skillet, cook kale until wilted (1-2 minutes), then add garlic and crushed red pepper, cooking for 30 seconds.",
                            Name = "Tomato Soup with Beans & Greens"
                        },
                        new
                        {
                            Id = 19,
                            Description = "Simmer salsa, water, and rice for 5 minutes, then add beans and cook. until rice is tender.",
                            Name = "Steak Burritos"
                        },
                        new
                        {
                            Id = 20,
                            Description = "Heat oil in a skillet, add breadcrumbs and garlic; cook, stirring, until toasted. Add beans and cook until rice is tender, about 5 more minutes.",
                            Name = "Easy Pea & Spinach Carbonara"
                        },
                        new
                        {
                            Id = 21,
                            Description = "Boil water, cook pasta per package instructions, reserve ½ cup cooking water, and drain. Blend spinach, basil, oil, lemon juice, garlic, and salt until smooth.",
                            Name = "Spaghetti with Lemon-Spinach Sauce"
                        },
                        new
                        {
                            Id = 22,
                            Description = "Toss with sesame oil, roast at 450°F for 6 mins. Drizzle with teriyaki glaze, broil until crispy.",
                            Name = "Crispy Salmon Rice Bowl"
                        },
                        new
                        {
                            Id = 23,
                            Description = "Sauté with half the garlic, salt, and red pepper until just cooked (4–5 mins); transfer to a plate. In the same skillet, add broccoli, bell peppers, water, remaining garlic, and salt; cover and cook until tender-crisp.",
                            Name = "One-Skillet Garlicky Salmon & Broccoli"
                        },
                        new
                        {
                            Id = 24,
                            Description = "Cook onion, carrots, celery, and garlic in butter until soft; add tarragon, seasoning, pepper. Add broth, bring to a boil, stir in tortellini, and cook covered until al dente (about 5 mins).",
                            Name = "Chicken Tortellini Soup"
                        });
                });

            modelBuilder.Entity("ProzhektAPI.Data.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<double>("Bmi")
                        .HasColumnType("float");

                    b.Property<int>("Height")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Weight")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ProzhektAPI.Data.Models.Workout", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Workouts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Hold your body in a straight line off the ground.",
                            Name = "Plank"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Works glutes, quads, and hamstrings; lower your hips down and back like you're sitting in a chair, then push through your heels to stand.  \r\n",
                            Name = "Squat"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Strengthens glutes and hamstrings; lie on your back, lift one leg, and push through the other heel to raise your hips.  \r\n",
                            Name = "Single Leg Bridge"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Focuses on upper abs; lie on your back, knees bent, and lift your shoulders off the floor using your core.  \r\n",
                            Name = "Crunch"
                        },
                        new
                        {
                            Id = 5,
                            Description = "Hits lower abs and hip flexors; lie on your back and rapidly alternate kicking your straight legs up and down a few inches off the ground.",
                            Name = "Flutter Kicks"
                        },
                        new
                        {
                            Id = 6,
                            Description = "Engages core and back; on all fours, extend opposite arm and leg straight, then switch sides.  ",
                            Name = "Bird Leg"
                        },
                        new
                        {
                            Id = 7,
                            Description = "Loosens spine and works core; alternate between arching your back up (cat) and dipping it down (cow) while on all fours.",
                            Name = "Cat-Cow"
                        },
                        new
                        {
                            Id = 8,
                            Description = "Boosts cardio and works full body; squat slightly then explode upward, spreading arms and legs like a star mid-air.  \r\n",
                            Name = "Star Jumps"
                        },
                        new
                        {
                            Id = 9,
                            Description = "Builds quads, glutes, and calves; jump to switch legs in a lunge position, landing softly each time.  \r\n",
                            Name = "Jumping Lunges"
                        },
                        new
                        {
                            Id = 10,
                            Description = "Targets glutes and hips; on hands and knees, lift one knee out to the side without tilting your torso.  \r\n",
                            Name = "Fire Hydrant"
                        },
                        new
                        {
                            Id = 11,
                            Description = "Works obliques and abs; sit with feet up, lean back slightly, and twist your torso side to side.  \r\n",
                            Name = "Russian Twists"
                        },
                        new
                        {
                            Id = 12,
                            Description = "Strengthens abs and hip flexors; lie on your back and use your core to lift your upper body to a seated position.",
                            Name = "Sit Up"
                        });
                });

            modelBuilder.Entity("ProzhektAPI.Data.Models.FavoriteRecipe", b =>
                {
                    b.HasOne("ProzhektAPI.Data.Models.Recipe", "Recipe")
                        .WithMany()
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProzhektAPI.Data.Models.User", "User")
                        .WithMany("FavoriteRecipes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Recipe");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ProzhektAPI.Data.Models.FavoriteWorkout", b =>
                {
                    b.HasOne("ProzhektAPI.Data.Models.User", "User")
                        .WithMany("FavoriteWorkouts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProzhektAPI.Data.Models.Workout", "Workout")
                        .WithMany()
                        .HasForeignKey("WorkoutId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");

                    b.Navigation("Workout");
                });

            modelBuilder.Entity("ProzhektAPI.Data.Models.User", b =>
                {
                    b.Navigation("FavoriteRecipes");

                    b.Navigation("FavoriteWorkouts");
                });
#pragma warning restore 612, 618
        }
    }
}
