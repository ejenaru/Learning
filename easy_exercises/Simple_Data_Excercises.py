#1 Escribir un programa que muestre por pantalla la cadena ¡Hola Mundo!.

print("¡Hola Mundo!")

#2 Create a program that asks the user to enter their name and their age.
# Print out a message addressed to them that tells them the year that they will turn 100 years old.

import datetime
print("This programm tells you the year when you will turn any age.")

name=input("Introduce your name: ")

age = -1
age_desired=-1
while age < 0:
    try:
        age=int(input("Introduce your age: "))
    except ValueError:
        print("Error, try a real age")
        age = -1

while age_desired<0:
    try:
        age_desired=int(input("Introduce desired age: "))
    except ValueError:
        print("Error, try a real age")
        age_desired = -1
    if (age >= age_desired) and (age_desired !=-1):
        print("Please, insert a higher number")
        age_desired = -1

year_today=datetime.datetime.now().year

year_future= year_today+ (age_desired-age)


print("Hello,", name, "you will turn", age_desired, "years in", year_future)

print("Hello, {0}, you will turn {1} years in {2}! :)".format(name, age_desired, year_future)) #another way