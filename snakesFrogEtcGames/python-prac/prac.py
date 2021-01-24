print("htllo")
print(1+2)
print(2.3333)
print(10120312*12312)
print(2>1)

print(not(2>1))
print(3//2)
print(3%2)
print(3/2)

print(abs(-2))
print(round(2.4))
print(pow(2,3))
print(max(2,5))
from math import *
print(floor(4.99))
print(ceil(2.2))
print(sqrt(16)) 

from random import *
print(random())
#input() #입력

jumon = "990102-1234567"
print("성별 : "+ jumon[7])
print("연 : "+jumon[0:2])
print("월 : "+jumon[2:4])
print(jumon[-7:]) #뒤에서 7번ㅉ부터 끝까지 

testW = "pyPy taro card"
print(testW.lower())
print(testW.upper())
print(testW[1].isupper())
print(len(testW))
print(testW.replace('py','Java')) 

index = testW.index('t')
print(index)
print(testW.find('t'))
print(testW.count('p'))
#index와 find 없는 것을 검색할 떄 find는 -1을 주고 index는 오류냄 

#문자형 포맷
#1
print('나는 %d 살 입니다 %s 입니다' % (36,"성인"))
print('나는 %s 를 좋아합니다' % "씨와 자바스크립트")
print('apple %c로 시작해요' % "a")
#2
print("나는 과일 {}와 {}를 좋아해요".format("apple","pineapple"))
print("나는 과일 {1}와 {0}를 좋아해요".format("apple","pineapple"))
#3
print("나는 {age}살이며, {color}색을 좋아합니다".format(age=20, color="빨간"))

#4
ag =20
col = "파랑"
print(f"{ag}살이고 {col}을 좋합니다")
#리스트
subway =[10,20,30,50]
print(subway)
subway.append(40)
print(subway)
subway.sort()
print(subway)
subway.reverse()
print(subway)
subway.pop()
print(subway)
subway.remove(20)
print(subway)

my_list1 = [1,2,3,4,5]
my_list2 = ["조세호",20,True]
print(my_list1)
my_list1.extend(my_list2)#리스트합치기
print(my_list1)
#딕셔너리 dictionary
cabinet = {3:"유재석",100:"조세호"}
print(cabinet[3])
print(cabinet.get(3))
print(cabinet.get(5)) #그냥 대괄호랑 했을 떄 차이는 대괄호는 그냥 오류남
print(cabinet.get(5,"사용가능")) #쩐다
print(3 in cabinet)
print(5 in cabinet)
cabinet2 = {"A-3":"유재석","d-3":"조세호"}
print(cabinet2["A-3"])
cabinet2["c20"] = "강호동"
print(cabinet2)
del cabinet2["c20"]
print(cabinet2)

print(cabinet2.keys())
print(cabinet2.values())
print(cabinet2.items())

#튜플 tuple
menu = ("돈까스","치즈까지")
print(menu[0])
print(menu[1])
#추가 안됨 menu.add 오류남

# name = "기종국"
# age = 20
# hobby = "코딩"
name, age, hobby = ("기종국",20,"코딩")

#세트
#중복 안됨 순서 없음
my_set = {1,2,3,4,5,5}
print(my_set)

java = {"유재석", "김태호","양세형"}
python = set(["유재석","박명수"])
#교집합
print(java&python)
print(java.intersection(python))

#합집합
print(java|python)
print(java.union(python))

#차집합
print(java.difference(python))
print(java - python)

python.add("김태호")
print(python)

java.remove("김태호")
print(java)

#자료 구조 변경
menu1 = {"커피","우유","쥬스"}
print(menu1, type(menu1))

menu1 = list(menu1)
print(menu1, type(menu1))

menu1 = tuple(menu1)
print(menu1, type(menu1))

menu1 = set(menu1)
print(menu1,type(menu1))

#댓글 20명 , 1명 치킨 3명 커피 랜덤 
#randome 모듈의 셔플 샘플 사용
from random import *
lst99 = [1,23,4,5,6,2,1,2,56]
print(lst99)
shuffle(lst99)
print(lst99)
print(sample(lst99,1))

users = range(1,21)
print(type(users))
users = list(users)
print(type(users))
print(users)
shuffle(users)
print(users)

winners = sample(users,4)
print("--당첨자 발표--")
print("치킨 당첨차 {0}".format(winners[0]))
print("커피 당첨차 {0}".format(winners[1:]))

for waiting_no  in [0,2,3]:
    print("대기번호 : {0}".format(waiting_no))

for waiting_no1 in range(1,5):
    print("대기번호 : {0}".format(waiting_no1))

starbucks = ["아이언맨","토르","아이엠 그루트"]
for customer in starbucks:
    print("{0}, 커피가 준비되었습니다".format(customer))
customer1 = "토르"
index =5
while index >= 1:
    print("{0},{1}회 남았습니다".format(customer,index))
    index -= 1
    if index == 0:
        print("커피 폐기")


# customer2 = "토르"
# person = "Unknown"
# while person != customer2 :
#     print("{0}, 커피가 준비되었씁니다".format(customer2))
    # person = input("이름이 어떻게 되세요") #이게 없으면 평생 반복

stud1 = [1,2,3,4]
print(stud1)
stud1 = [i+100 for i in stud1]
print(stud1)

#50명 손님 5~50분 난수 , 5~15분만 걸리는 승객만 매칭 
customer2 = range(1,51)
customer2 = list(customer2)
print(customer2)

from random import *
cntllo =0
for i in range(1,51):
    time = randrange(5,51)
    if 5<= time <=15:
        print("[0] : {0}번쨰 손님 {1}분 입니다".format(i, time))
        cntllo +=1
    else:
        print("[ ]:  {0}번째 손님 소요시간 : {1}".format(i,time))
print("총 탑승 승객 : %d" % cntllo)

#함수
def open_account():
    print("새로운 ㄱ좌 생성 되었습니다")
open_account()

def deposit(balance, money):
    print("입금이 완료 되었습니다. 잔액은 {0} 원입니다".format(balance+money))
    return balance + money
balance = 0
balance = deposit(balance, 1000)
print(balance)

def withdraw(balance, money):
    if balance >= money:
        print("출금이 완료 ㅇ되었습니다 잔액은 {0}입니다".format(balance - money))
        return balance - money
    else:
        print("출금이 완룓 ㅚ지 않았습니다 잔액{0} ".format(balance))
        return balance

balance = withdraw(balance, 2000)
balance = withdraw(balance, 500)

#함수
def profile(name, age=18, main_lang="파이선"):#기본 값은 아무것도 안적혔을 때 저굥ㄷ힌다
    print("이름 : {0} \t 나이 : {1} \t 사용언어: {2}".format(name,age, main_lang))

#가변인자
def profile1(name, age, lang1, lang2):
    print("이름 : {0} \t 나이: {1} \t ".format(name, age), end=" ") #줄바꿈 없음 end

def profile2(name, age, *lang):
    print("이름 {0} 나이 {1}".format(name,age), end=" ")
    for l in lang:
        print(l, end = " ")

print(profile2("asdasd",11,"a","b","c"))


gun = 10
def checkpoint(soldier):
    global gun #전역 변수를 불러옴 
    gun = gun - soldier
    print("{0}".format(gun))

print("전체 ㄹ총 {0}".format(gun))
checkpoint(2)

#표준 입추력
import sys
print("python", "java", file=sys.stdout) 
print("python", "java", file=sys.stderr) #표준 에러 출력
#정렬
scores = {"수학":0,"영어":50,"코딩":100}
for subject, score in scores.items():
    print(subject.ljust(8), str(score).rjust(4), sep=":")
    
print("{0: >10}".format(500)) # 오른쪽 정렬 
print("{0: >+10}".format(500)) # 오른쪽 정렬  앞에 부호를 붙여두면 양음에 따라 바뀜
print("{0: >+10}".format(-500))

print("{0:_>+10}".format(500)) #빈 공간 대신 언더바

print("{0:,}".format(10000000)) #3자리마다 콤마 
print("{0:+,}".format(10000000)) #3자리마다 콤마 부호 붙이면 됨 

#특정 소수자리까지
print("{0:.2f}".format(5/3)) #2쨰까지
score_file = open("python-prac/score.txt","w",encoding="utf8")#w대신 a하면 추가및생성
print("수학:0", file=score_file)
print("영어:50", file=score_file)
score_file.close()

socre_file2 = open("python-prac/score.txt","r",encoding="utf8")
print(socre_file2.read())

while True:
    line = socre_file2.readline()
    if not line:
        break
    print(line)
socre_file2.close()

import pickle
profile_file = open("python-prac/profile.pickle","wb")
prifile = {"이름":"qkraudtn","나이":30,"hobbies":["c","a"]}
print(prifile)
pickle.dump(prifile, profile_file)
profile_file.close()

profile_file2 = open("python-prac/profile.pickle","rb")
profile2= pickle.load(profile_file2)
print(profile2)
profile_file2.close()

#class
 #클래스
 #일반유닛
class Unit:
    def __init__(self,name,hp, speed): #생성자
        self.name = name
        self.hp = hp
        self.speed = speed
        print("{0} 유닛이 생성 되었습니다".format(name))

    def move(self, location):
        print("지상 유닛 이동")
        print("{0} : {1}으로 ㅇ동합니다 속도 : {2}".format(self.name, location, self.speed))
        # self.damage = damage
        # print("{0} 유닛이 생성 되었습니다".format(self.name))
        # print("체력이{0} 데미지가 {1}".format(self.hp, self.damage))
    def damaged(self, damage):
        print("{0} : {1} 피해를 입었습니다".format(self.name, damage))
        self.hp -= damage
        print("{0} : 현재 체력은 {1}입니다".format(self.name,self.hp))
        if self.hp <= 0:
            print("{0}:파괴 되었습니다".format(self.name))


#외부에서 변수를 추가해서 ㅅ용하기
# wraith1 = Unit("레이스",80,20)
# wraith1.clocking = True
# if wraith1.clocking ==True:
#     print("{0}는 현재 클롱킹 상태 입니다".format(wraith1.name))

#공격 유닛 위에 유닛 상속 받게 함 
class AttackUnit(Unit):
    def __init__(self,name,hp, speed, damage): #생성자
        Unit.__init__(self, name, hp, speed)
        self.damage = damage
    
    def attack(self, location):
        print("{0}:{1}으로 적군 공격 합니다 공격력 {2}"
        .format(self.name, location, self.damage))


firebat1 = AttackUnit("파뱃",50,16,2)
#날 수 있는 기능을 가진 클래스
class Flyable:
    def __init__(self, flying_speed):
        self.flying_speed = flying_speed
    def fly(self, name, locaiton):
        print("{0} : {1}방향으로 날아갑니다 속도 : {2}".format(name, locaiton, self.flying_speed))


#공중 공격 유닛 클래스
class FlyableAttackUnit(AttackUnit, Flyable):
    def __init__(self, name, hp, damage, flying_speed):
        AttackUnit.__init__(self, name, hp,0, damage) #지상아니니까 0 
        Flyable.__init__(self, flying_speed)
    def move(self, location):
        print("공주 유닛 이동")
        self.fly(self.name, location)
    

#발키리 한버에 14발 미사일 
valkyrie = FlyableAttackUnit("발키리", 200, 6, 5)
valkyrie.fly(valkyrie.name,"3시")

#오버라이딩
#벌쳐 
vulture = AttackUnit("벌쳐", 80, 10, 20)
#배틀 크루저
battlecruiser = FlyableAttackUnit("배틀크루저",450,30,3)

vulture.move("11시")
battlecruiser.fly(battlecruiser.name,"9시")

battlecruiser.move("9시")

#pass
class BuildingUnit(Unit):
    def __init__(self, name, hp, location):
       super().__init__(name, hp, 0)#Unit.__init__(self, name, hp, 0) #슈퍼할시 self 안써도 됨 다중 상속시 문제됨
       self.location = location

#서플ㄹㅏ이디폿 : 건물
supply_depot = BuildingUnit("서플라이 디폿",500, "9시")

def game_start():
    print("알림] 새로운 게임을 시작 합니다")
def game_over():
    pass

game_start()
game_over()


class Marine(AttackUnit):
    def __init__(self):
        AttackUnit.__init__(self, "마린", 40, 1, 5)
    def stimPack(self):
        if self.hp > 10:
            self.hp -= 10
            print("{0} : 스팀팩을 사용 합니다".format(self.name))
        else:
            print("{0} : 체력이 부족하ㅕㅇ 사용 하지 않습니다".format(self.name))

class Tank(AttackUnit): #탱크 지상 고정 시즈모드
    seize_develpoed = False
    def __init__(self):
        AttackUnit.__init__(self, "탱크",150, 1, 35)
        self.seize_mode = False
    def set_seize_mode(self):
        if Tank.seize_develpoed == False:
            return
        if self.seize_mode == False:
            print("{0} : 시즈모드로 전환 합니다 . ".format(self.name))
            self.damage *= 2
            self.seize_mode = True
        else:
            print("{0} : 시즈모드로 해제 합니다 . ".format(self.name))
            self.damage /= 2
            self.seize_mode = False

#Wraith
class Wraith(FlyableAttackUnit):
    def __init__(self):
        FlyableAttackUnit.__init__(self,"레이스", 80, 20, 5)
        self.clocked = False

    def clocking(self):
        if self.clocked == True : 
            print("{0} : 클로킹 모드를 해제합니다".format(self.name))
            self.clocked = False
        else:
            print("{0} : 클로킹 모드를 설정합니다".format(self.name))
            self.clocked = True

try:
    print("나누기")
    num1 = int(input("첫번재 숫자 입력하세요 : "))
    num2 = int(input("두번재 숫자 입력하세요 : "))
    print("{0} / {1} = {2}".format(num1, num2, int(num1/num2)))
except ValueError:
    print("자못된 값으 ㄹ입력")
except ZeroDivisionError as err:
    print(err)

from bs4 import BeautifulSoup
soup = BeautifulSoup("https://www.naver.com")
print(soup.prettify())
