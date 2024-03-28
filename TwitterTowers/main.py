from rectangle import Rectangle
from triangle import Triangle


def Receiving_width_and_height():
    while True:
        try:
            height = float(input("Enter the height: "))
            width = float(input("Enter the width: "))
            if height < 2 or width < 1:
                print(
                    "A tower must have a height greater than or equal to 2 and a width greater than or equal to 1.")
                continue
            return width,height
        except ValueError:
            print("Invalid choice! Please enter a number.")
            continue


def main():
    while True:
        print("\nMenu:")
        print("1. Rectangle")
        print("2. Triangle")
        print("3. Exit")
        try:
            choice = int(input("Enter your choice: "))
        except ValueError:
            print("Invalid choice! Please enter a number between 1 and 3.")
            continue
        if choice == 1:
            Rectangle(*Receiving_width_and_height()).print()
        elif choice == 2:
            Triangle(*Receiving_width_and_height()).print()
        elif choice == 3:
            print("Exiting the program...")
            break
        else:
            print("Invalid choice! Please enter a number between 1 and 3!")


if __name__ == "__main__":
    main()
