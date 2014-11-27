<?PHP
$ruta="imagenes/".basename($_FILES['fotoUp'] ['name']);
if(move_upload_file($_FILES['fotoUp']['tmp_name'],$ruta))
		chmod("uploads/".basename($_FILES['fotoUp']['name]),0644);
?>