#-*-coding:utf-8-*-

import datetime

# First I create a function that has no input and returns a str with the current date
def getCurrentDate():
	"""Return the current date in format 'Friday, 28/August/2020'"""

	# Datetime object 'tod' for saving 'today' date
	tod= datetime.datetime.today()

	# Transform 'tod' to our favourite format
	today_f=tod.strftime("%A, %d/%B/%Y")

	return(today_f)

#This function returns the local temperature based on a website for Madrid
def getCurrentTemp():
	pass




def main():
	print(getCurrentDate())

if __name__ == "__main__":
    main()


