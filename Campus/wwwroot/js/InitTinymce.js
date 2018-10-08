document.write("<script language=javascript src='../lib/tinymce/tinymce.min.js'></script >");
$(function () {
    tinymce.init({
        selector: '#mytextarea',
        images_upload_url: "/upload/create",
        images_upload_credentials: true,
        plugins: [
            'advlist autolink link image lists charmap print preview hr anchor pagebreak spellchecker',
            'searchreplace wordcount visualblocks visualchars code fullscreen insertdatetime media nonbreaking',
            'save table contextmenu directionality emoticons template paste textcolor'
        ],
        toolbar: 'insertfile undo redo | styleselect | bold italic | alignleft aligncenter alignright alignjustify | bullist numlist outdent indent | link image | print preview media fullpage | forecolor backcolor emoticons'
    });
});