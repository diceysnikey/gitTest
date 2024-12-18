while True:
    username = input("Enter your username (Under 12 characters): ")
    if len(username) >= 12:
        print("Your username is too long!")
    else:
        break