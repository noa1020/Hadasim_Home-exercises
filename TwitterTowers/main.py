import math


def Receiving_width_and_height():
    while True:
        try:
            height = float(input("Enter the height: "))
            width = float(input("Enter the width: "))
            if height < 2 or width < 1:
                print("A tower must have a height greater than or equal to 2 and a width greater than or equal to 1.")
                continue
            return height, width
        except ValueError:
            print("Invalid choice! Please enter a number.")
            continue


def rectangle():
    height, width = Receiving_width_and_height()
    if height == width or abs(height - width) > 5:
        print("Area of the rectangle:", height * width)
    else:
        print("Perimeter of the rectangle:", 2 * (height + width))


def triangle_perimeter(base, height):
    side = math.sqrt((base / 2) ** 2 + height ** 2)
    perimeter = base + 2 * side
    return perimeter


def print_triangle(width, height):
    middle_rows = height - 2
    profit = width // 2
    print(" "*profit + '*')
    profit -= 1
    asterisks = 3
    rows_numbers = (height*2) // (width-2)
    count = 0
    for i in range(middle_rows):
        if asterisks >= width:
            break
        count += rows_numbers
        i += rows_numbers
        asterisks += 2
    asterisks = 3
    for i in range(middle_rows-count):
        print(" "*profit + '*' * asterisks)
    for i in range(middle_rows):
        if asterisks >= width:
            break
        for j in range(rows_numbers):
            print(" "*profit + '*' * asterisks)
            i += 1
        asterisks += 2
        profit -= 1
    print('*' * width)


def triangle():
    height, base = Receiving_width_and_height()
    while True:
        try:
            option = int(input("Choose an option:\n1. Calculate perimeter\n2. Print triangle\nOption: "))
        except ValueError:
            print("Invalid choice! Please enter a number between 1 and 3.")
            continue
        if option == 1:
            perimeter = triangle_perimeter(base, height)
            print("Perimeter of the triangle:", perimeter)
            break
        elif option == 2:
            if base % 2 == 0 or base >= 2 * height:
                print("Cannot print triangle.")
                break
            else:
                print_triangle(int(base), int(height))
                break
        else:
            print("Invalid option!")


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
            rectangle()
        elif choice == 2:
            triangle()
        elif choice == 3:
            print("Exiting the program...")
            break
        else:
            print("Invalid choice! Please enter a number between 1 and 3!")


if __name__ == "__main__":
    main()
