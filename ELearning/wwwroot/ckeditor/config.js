/**
 * @license Copyright (c) 2003-2023, CKSource Holding sp. z o.o. All rights reserved.
 * For licensing, see https://ckeditor.com/legal/ckeditor-oss-license
 */

CKEDITOR.editorConfig = function (config) {
	// Define changes to default configuration here. For example:
	config.language = 'hi';
	config.scayt_autoStartup = true;
	// config.language = 'fr';
	// config.uiColor = '#AADC6E';
	//config.font_names = 'KrutiDev/krutidev_070-webfont;' + config.font_names;
	/*config.font_names = 'Mangal/Mangal;' + config.font_names;*/
	config.font_names = 'Akshar';
	config.toolbarGroups = [
		{ name: 'clipboard', groups: ['clipboard', 'undo'] },
		{ name: 'editing', groups: [ 'spellchecker'] },
		{ name: 'links', groups: ['links'] },
		{ name: 'insert'},
		//{ name: 'forms', groups: ['forms'] },
		{ name: 'tools', groups: ['tools'] },
		//{ name: 'document', groups: ['mode', 'doctools'] },
		{ name: 'others', groups: ['others'] },
		'/',
		{ name: 'basicstyles', groups: ['basicstyles', 'cleanup', 'Underline', 'Subscript','Superscript'] },
		{ name: 'paragraph', groups: ['list', 'indent', 'blocks', 'align', 'bidi', 'paragraph'] },
		{ name: 'styles', groups: ['styles'] },
		{ name: 'colors', groups: ['colors'] },
		{ name: 'about', groups: ['about'] }
	];

	config.removeButtons = 'baloontoolbar,easyimage,cloudservices ,find, editing,Form, smiley,Iframe,Anchor,Language,CreateDiv','document','exportpdf';
	//config.extraPlugins = 'mathjax';
	config.fontSize_defaultLabel = '14px';

	//config.mathJaxLib = '//cdnjs.cloudflare.com/ajax/libs/mathjax/2.7.0/MathJax.js?config=TeX-AMS_HTML';

	//config.mathJaxLib = "~/js/MathJax.js?config=TeX-AMS_HTML";
};
//CKEDITOR.config.customConfig: '~/js/MathJax.js?config=TeX-AMS_HTML';
