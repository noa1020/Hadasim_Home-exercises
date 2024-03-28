import math
from shape import Shape


class Rectangle(Shape):
    def __init__(self, width, height):
        super().__init__(width, height)

    # Checking whether to print perimeter or area
    def print(self):
        if self.height == self.width or abs(self.height - self.width) > 5:
            print("Area of the rectangle:", self.area_calculate())
        else:
            print("Perimeter of the rectangle:", self.perimeter_calculate())

    def perimeter_calculate(self):
        return 2 * (self.height + self.width)

    def area_calculate(self):
        return self.width * self.height
