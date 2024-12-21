while True:
    choice, num1, num2 = input("Which operation do you want to perform? (+, -, *, /): "), int(input("Enter the first number: ")), int(input("Enter the second number: "))
    match choice:
        case "+":
            result = num1 + num2
        case "-":
            result = num1 - num2
        case "*":
            result = num1 * num2
        case "/":
            while True:
                if num2 != 0:
                    result = num1 / num2
                    break
                else:
                    num2 = int(input("You can't divide by 0! Re-enter the number to divide by: "))
        case _:
            print("Enter a valid operation!")
    print(f"The result from performing {choice} with {num1} and {num2} is: {result}")
    again = input("Do you want to do another calculation? (Y/N): ")
    if again.upper() == "N":
        print("Goodbye!")
        break