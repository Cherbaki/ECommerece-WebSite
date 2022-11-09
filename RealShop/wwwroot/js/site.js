
var CategoriesButton = document.getElementById("CategoriesButton");
var CategoriesList = document.getElementById("CategoriesList");
var togglerButton = document.getElementById("togglerButton");
var CategoriesListItem = document.getElementsByClassName('CategoriesItemForList');


CategoriesButton.onmouseover = function () {
    if (CategoriesList.className == 'CategoriesHide CategoriesWhenUserIsNotLoggedIn')
        CategoriesList.className = 'CategoriesShow CategoriesWhenUserIsNotLoggedIn';
    else if (CategoriesList.className == 'CategoriesHide CategoriesWhenUserLoggedIn')
        CategoriesList.className = 'CategoriesShow CategoriesWhenUserLoggedIn'
}

CategoriesList.onmouseover = function () {
    if (CategoriesList.className == 'CategoriesHide CategoriesWhenUserIsNotLoggedIn')
        CategoriesList.className = 'CategoriesShow CategoriesWhenUserIsNotLoggedIn';
    else if (CategoriesList.className == 'CategoriesHide CategoriesWhenUserLoggedIn')
        CategoriesList.className = 'CategoriesShow CategoriesWhenUserLoggedIn'
}

CategoriesList.onmouseout = function () {
    if (CategoriesList.className == 'CategoriesShow CategoriesWhenUserIsNotLoggedIn')
        CategoriesList.className = 'CategoriesHide CategoriesWhenUserIsNotLoggedIn';
    else if (CategoriesList.className == 'CategoriesShow CategoriesWhenUserLoggedIn')
        CategoriesList.className = 'CategoriesHide CategoriesWhenUserLoggedIn';
}

togglerButton.onclick = function () {
    if (CategoriesList.className.includes('CategoriesHide')) {
        if (CategoriesList.className.includes('CategoriesWhenUserIsNotLoggedIn'))
            CategoriesList.className = 'CategoriesShow CategoriesWhenUserIsNotLoggedIn';
        else if (CategoriesList.className.includes('CategoriesWhenUserLoggedIn'))
            CategoriesList.className = 'CategoriesShow CategoriesWhenUserLoggedIn';
    }
    else if (CategoriesList.className.includes('CategoriesShow'))
    {
        if (CategoriesList.className.includes('CategoriesWhenUserIsNotLoggedIn'))
            CategoriesList.className = 'CategoriesHide CategoriesWhenUserIsNotLoggedIn';
        else
            CategoriesList.className = 'CategoriesHide CategoriesWhenUserLoggedIn';
    }
}