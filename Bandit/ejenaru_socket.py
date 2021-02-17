import socket

pw = "UoMYTrfrBFHyQXmg6gzctqAwOmw1IohZ"



def connection(pin):


    s = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
    s.connect(("localhost", 30002))
    data = s.recv(1024)
    psw = "{0} {1}\n".format(pw, pin).encode()
    s.send(psw)
    data = s.recv(1024)
    s.send(b"quit\n")
    s.close()
    return data

output = connection(0000)

for i in range(10000):

    pin = str(i).zfill(4)
    ret = connection(pin)
    print("Probando: {0}".format(pin))
    if ret != output:
        print("La contraseña es: {0} {1}".format(pw,pin))
        break
