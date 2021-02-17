from django.http import HttpResponse, HttpResponseNotFound
from photos.models import Photo, PUBLIC
from django.shortcuts import render

# Create your views here. Views are controllers. We call them in the URLS.py

# every view takes a REQUEST object and returns a RESPONSE object
def home(request):
    photos = Photo.objects.filter(visibility=PUBLIC).order_by("-created_at")
    context = { #context is a dictionary, very important
        "photos_list": photos
    }

    return render(request, 'photos/home.html', context)
    # render returns a response object. It takes the request (for user-authentication-things),
    # the template that we want to show and the context (the variables that the template is gonna use)
    # we need to create a dir with the name of the app inside (photos/templates/photos/home.html) bc
    # render searchs through every "template" directory, looking for the html that we are giving
    # if we have two apps, and both of them use "home.html", render does not know wich one.

def detail(request, pk):
    """
    carga la página de detalle de una foto
    :param request: HttpRequest
    :param pk:  id de la foro
    :return: HttpResponse
    """
    """ Se podría hacer esto pero es poco legible.
    try:
        photo = Photo.objects.get(pk=pk)
    except Photo.DoesNotExist:
        photo = None
    except Photo.MultipleObjects:
        photo = None"""

    possible_photos = Photo.objects.filter(pk=pk)
    photo = possible_photos[0] if len(possible_photos) == 1 else None

    if photo is not None:

        # cargar la plantilla de detalle
        context = {
            "photo": photo
        }
        return render(request, "photos/detail.html", context)
    else:
        return HttpResponseNotFound("No existe la foto") # 404 Not Found