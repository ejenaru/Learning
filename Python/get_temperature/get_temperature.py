# -*-coding:utf-8-*-

import datetime
import requests
from bs4 import BeautifulSoup


def get_current_date():
	"""Return the current date in format 'Friday, 28/August/2020'"""
	tod = datetime.datetime.today()
	today_f = tod.strftime("%A, %d/%B/%Y")

	return today_f


def get_page(url):

	page_resp = requests.get(url)
	page_cont = page_resp.content
	return page_cont


def get_temp(page):

	soup = BeautifulSoup(page, "html.parser")
	# soup is the html of the page but in a beautiful version
	table = soup.find(class_="borde_izq_dcha_estado_cielo no_wrap")
	temp = table.find("div", class_="no_wrap").text
	# soup is the block that has the information that I want
	return temp


def save_temp(temp, date, filename="temperature.txt"):
	text = "Today is {0} and the temperature is: {1}\n".format(date, temp)

	file = open(filename, "a+")
	file.write(text)
	file.close()
	file = open(filename, "r")
	filecontent = file.read()
	file.close()
	return filecontent


def main():
	url = "http://www.aemet.es/es/eltiempo/prediccion/municipios/madrid-id28079"
	page = get_page(url)
	temp = get_temp(page)
	date = get_current_date()

	print(save_temp(temp, date))


if __name__ == "__main__":
	main()
