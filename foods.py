import os

if not os.path.exists("favorite_foods.txt"):
    with open ("favorite_foods.txt", "w") as file:
        pass

with open("favorite_foods.txt", "r+") as file:
    foods = set(line.strip().lower() for line in file)
    while True:
        food = input("Enter your favorite food: ")
        if food.lower() in foods:
            print("This food is already in the list!")
        else:
            file.write(f"{food}\n")
            foods.add(food)
        choice = input("Do you want to add another item? (Y/N): ")
        if choice.upper() == "N":
            break
    
    for food in foods:
        print(f"{food}")
    