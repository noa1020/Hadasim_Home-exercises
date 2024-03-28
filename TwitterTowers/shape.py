from abc import ABC, abstractmethod


class Shape(ABC):
    def __init__(self, width, height):
        self.width = width
        self.height = height

    @abstractmethod
    def perimeter_calculate(self):
        pass

    @abstractmethod
    def print(self):
        pass
