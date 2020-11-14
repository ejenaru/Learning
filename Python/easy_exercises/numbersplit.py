
def numbersplit(num):
  cifra=1
  a=1
  while cifra > 0:
    cifra=int((num%(10*a)-(num%a))/a)
    print(cifra)
    a*=10

numbersplit(234)


def numbersplit_1 (num):
  lista=[]
  aux=num
  cifra=0
  while aux>0:
    cifra=aux%10
    lista.insert(0,cifra)
    aux=aux//10

  return lista
  
print(numbersplit_1(1234567890))