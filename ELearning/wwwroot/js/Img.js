$(document).ready(function () {
    $("#imageGallery").imagePopup({
        overlay: "rgba(0, 0, 0, 0.7)",

        closeButton: {
            src: "img/close.png",
            width: "40px",
            height: "40px"
        },
        imageBorder: "10px solid #ffffff",
        borderRadius: "6px",
        imageWidth: "800px",
        imageHeight: "auto",
        imageCaption: {
            exist: true,
            color: "#ffffff",
            fontSize: "18px"
        },
        open: function () {
            console.log("opened");
        },
        close: function () {
            console.log("closed");
        }
    });

});