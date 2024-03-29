import math
from shape import Shape

# Define constants and spacings
SPACE = " "
ASTERISK = "*"
NEWLINE = "\n"


class Triangle(Shape):
    def __init__(self, width, height):
        super().__init__(width, height)

    #A function that returns the perimeter of a triangle
    def perimeter_calculate(self):
        side = math.sqrt((self.width / 2) ** 2 + self.height ** 2)
        perimeter = self.width + 2 * side
        return perimeter

    #A function that prints a triangle using asterisks
    def print_triangle(self):
        width = int(self.width)
        height = int(self.height)
        #Edge case
        if width == 1:
            print(height * NEWLINE + ASTERISK)
            return
        spaces = width // 2
        print(SPACE * spaces + ASTERISK)
        spaces -= 1
        asterisks = 3
        Number_of_lines_per_group = (height * 2) // (width - 2)
        Number_of_groups = (width - 2) // 2
        rest_of_lines = height - 2 - Number_of_lines_per_group * Number_of_groups
        for i in range(rest_of_lines):
            print(SPACE * spaces + ASTERISK * asterisks)
        for i in range(Number_of_groups):
            for j in range(Number_of_lines_per_group):
                print(SPACE * spaces + ASTERISK * asterisks)
            asterisks += 2
            spaces -= 1
        print(ASTERISK * width)
        
    # Checking whether to print the perimeter of a triangle or the shape of a triangle
    def print(self):
        while True:
            try:
                option = int(input("Choose an option:\n1. Calculate perimeter\n2. Print triangle\nOption: "))
            except ValueError:
                print("Invalid choice! Please enter a number between 1 and 3.")
                continue
            if option == 1:
                print("Perimeter of the triangle:", self.perimeter_calculate())
                break
            elif option == 2:
                if self.width % 2 == 0 or self.width > 2 * self.height:
                    print("Cannot print triangle.")
                    break
                else:
                    self.print_triangle()
                    break
            else:
                print("Invalid option!")
