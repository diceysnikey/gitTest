while True:
    username = input("Enter your username (Under 12 characters): ")
    if len(username) >= 12:
        print("Your username is too long!")
    elif len(username) == 0:
        print("Enter a username!")
    else:
        break