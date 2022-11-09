
var productImages = document.querySelectorAll('.productImage');
var ProductImagesFrame = document.getElementById('ProductImagesFrame');
var leftArrow = document.getElementById('leftArrow');
var rightArrow = document.getElementById('rightArrow');
var miniImages = document.querySelectorAll('.miniImage');


for (var i = 0; i < miniImages.length; i++) {

    miniImages[i].onmouseover = function () {
        productImages[curretnImageIndex].src = event.target.src;
    }

}


var curretnImageIndex = 0;
//Vanishing left arrow and displaying products main image
leftArrow.style.display = 'none';
productImages[curretnImageIndex].style.display = 'block';

rightArrow.addEventListener('click', function () {

    productImages[curretnImageIndex].style.display = 'none';
    curretnImageIndex += 1;

    //Displaying or not right arrow
    if (curretnImageIndex >= productImages.length - 1)
        rightArrow.style.display = 'none';
    else
        rightArrow.style.display = 'block';

    leftArrow.style.display = 'block';

    productImages[curretnImageIndex].style.display = 'block';

});

leftArrow.addEventListener('click', function () {

    productImages[curretnImageIndex].style.display = 'none';
    curretnImageIndex -= 1;

    //Displaying left arrow or not
    if (curretnImageIndex == 0)
        leftArrow.style.display = 'none';
    else
        leftArrow.style.display = 'block';

    rightArrow.style.display = 'block';

    productImages[curretnImageIndex].style.display = 'block';


});

