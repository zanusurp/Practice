class Unit:
    def __init__(self):
        print("유닛 생성자")
class Flyable:
    def __init__(self):
        print("플라이어 생선자")
class FlyableUnit(Unit, Flyable):
    def __init__(self):
        super().__init__() #두개 이상시 한쪽이 상속 안됨  맨  처음 것만

dropship  = FlyableUnit()