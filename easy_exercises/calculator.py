# -*-coding:utf-8-*-

# author: ejenaru

KEYWORDS = ['suma', 'resta', 'multiplica', 'divide', 'quit']
operador =""

while operador != "quit":
    operador = input("Introduce un operador " )

    if operador not in KEYWORDS:
        print('Has escrito {0} y no es una palabra clave. Debe introducir uno de los siguientes operadores: {1}'.format(operador, KEYWORDS))

    elif operador == "quit":
     print("¿Ya te vas? Hasta pronto.")

    else:
      
      numero_1 = float(input("Introduce el primer número: "))
      numero_2 = float(input("Introduce el segundo número: "))

      if operador == "suma":
        print("El resultado de tu SUMA es: " + str(numero_1+numero_2))

      elif operador == "resta":
        print("El resultado de tu RESTA es: " + str(numero_1-numero_2))

      elif operador == "multiplica":
        print("El restultado de tu MULTIPLICACIÓN es: " + str(numero_1*numero_2))

      elif operador == "divide":
        print("El resultado de tu DIVISIÓN es: " + str(numero_1/numero_2))
