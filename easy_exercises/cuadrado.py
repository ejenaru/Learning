#Cuadrado 

def linea(symbol,tam):
  try:
    for i in range(tam):
      print(symbol+" ", end="")
    print()  
  except SyntaxError:
    print("Error. \nIntroduce:(string,valor)")
   
def cuadrado_funcion(symbol,tam):
  try:
    for i in range(tam):
      linea(symbol,tam)
  except SyntaxError:
    print("Error. \nIntroduce:(string,valor)")
   
 
def cuadrado(symbol='*',tam=8): 
  try:
    for j in range(tam):
      for i in range(tam):
        print(symbol+" ", end="")
      print() 
    
  except:
    print("Error. \nIntroduce:(string,valor)")

def triangulo_rec(symbol="*",tam=5):
  for j in range(tam):
    for i in range(j+1):
      print(symbol+ " ", end="")
    print()
      
      
def triangulo_isos(symbol="*",tam=5):
  for j in range (tam):
    for i in range(tam-(j+1)):
      print(str(i), end='')
    for i in range (j+1):
      print(symbol+ " ", end="")
    print()
      

linea("*",8)
cuadrado()
triangulo_isos()
triangulo_rec()
