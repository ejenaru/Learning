#-*-coding:utf-8-*-

import datetime
import requests
# This function has no input and returns a str with the current date
def getCurrentDate():
	"""Return the current date in format 'Friday, 28/August/2020'"""

	# Datetime object 'tod' for saving 'today' date
	tod= datetime.datetime.today()

	# Transform 'tod' to our favourite format
	today_f=tod.strftime("%A, %d/%B/%Y")

	return(today_f)

#This function returns the local temperature based on a website for Madrid
def getPage(url):

	page_resp= requests.get(url)
	page_cont=page_resp.content
	return page_cont

def getTemp(page): #todo finish this function


	from bs4 import BeautifulSoup 
	soup = BeautifulSoup(page_cont,"html.parser")
	#soup is the html of the page but in a beautifull version

	return soup

def main():
	url="https://www.eltiempo.es/madrid.html"
	print(getCurrentDate())
	print(getTemp())

if __name__ == "__main__":
    main()


