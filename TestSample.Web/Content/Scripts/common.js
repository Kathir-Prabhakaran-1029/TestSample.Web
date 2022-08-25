jQuery(document).ready(function($) {
	$("#close-sidebar").click(function() {
	  $(".page-wrapper").removeClass("toggled");
	});
	
	$("#show-sidebar").click(function() {
	  $(".page-wrapper").addClass("toggled");
	});
	
	if($(window).width() > 800){
		$(".page-wrapper").addClass("toggled");
	}else{
		$(".page-wrapper").removeClass("toggled");
	}
	
	$(".QUOTATIONS .iconQuotation").addClass("active");
	$(".POLICIES .iconPolicies").addClass("active");
	$(".PAYMENT .iconPayment").addClass("active");
	$(".REPORTS .iconReports").addClass("active");
	$(".USERS .iconUsers").addClass("active");
	$(".INSURERS .iconInsurers").addClass("active");
	$(".PRODUCTS .iconProducts").addClass("active");
	
	$(".mainMenu").click(function() {
		var currentTab = $(this).attr("rel"); 
		if ($(this).parent().is(".active")) {
			$(".mainMenu").parent().removeClass("active");
			$("#"+currentTab).slideUp(200);	
		}else{
			$(".subMenu").hide();
			$(".mainMenu").parent().removeClass("active");
			$(this).parent().addClass("active");
			$("#"+currentTab).slideDown(200);	
		}
	});

	$("form").attr("autocomplete", "off");

	initAlphaNum();
});

$(window).resize(function() {
	if($(window).width() > 800){
		$(".page-wrapper").addClass("toggled");
	}else{
		$(".page-wrapper").removeClass("toggled");
	}
});

//(function() {
//    var link = document.querySelector("link[rel*='icon']") || document.createElement('link');
//    link.type = 'image/x-icon';
//    link.rel = 'shortcut icon';
//    link.href = 'https://mlionline.biz/grinweiv/images/favicon.png';
//    document.getElementsByTagName('head')[0].appendChild(link);
//})();

$( function()
		{
			var targets = $( '[rel~=tooltip]' ),
				target  = false,
				tooltip = false,
				title   = false;
		 
			targets.bind( 'mouseenter', function()
			{
				target  = $( this );
				tip     = target.attr( 'title' );
				tooltip = $( '<div id="tooltip"></div>' );
		 
				if( !tip || tip == '' )
					return false;
		 
				target.removeAttr( 'title' );
				tooltip.css( 'opacity', 0 )
					   .html( tip )
					   .appendTo( 'body' );
		 
				var init_tooltip = function()
				{
					if( $( window ).width() < tooltip.outerWidth() * 1.5 )
						tooltip.css( 'max-width', $( window ).width() / 2 );
					else
						tooltip.css( 'max-width', 340 );
		 
					var pos_left = target.offset().left + ( target.outerWidth() / 2 ) - ( tooltip.outerWidth() / 2 ),
						pos_top  = target.offset().top - tooltip.outerHeight() - 20;
		 
					if( pos_left < 0 )
					{
						pos_left = target.offset().left + target.outerWidth() / 2 - 20;
						tooltip.addClass( 'left' );
					}
					else
						tooltip.removeClass( 'left' );
		 
					if( pos_left + tooltip.outerWidth() > $( window ).width() )
					{
						pos_left = target.offset().left - tooltip.outerWidth() + target.outerWidth() / 2 + 20;
						tooltip.addClass( 'right' );
					}
					else
						tooltip.removeClass( 'right' );
		 
					if( pos_top < 0 )
					{
						var pos_top  = target.offset().top + target.outerHeight();
						tooltip.addClass( 'top' );
					}
					else
						tooltip.removeClass( 'top' );
		 
					tooltip.css( { left: pos_left, top: pos_top } )
						   .animate( { top: '+=10', opacity: 1 }, 50 );
				};
		 
				init_tooltip();
				$( window ).resize( init_tooltip );
		 
				var remove_tooltip = function()
				{
					tooltip.animate( { top: '-=10', opacity: 0 }, 50, function()
					{
						$( this ).remove();
					});
		 
					target.attr( 'title', tip );
				};
		 
				target.bind( 'mouseleave', remove_tooltip );
				tooltip.bind( 'click', remove_tooltip );
			});
});


// Custom Email validation Rule
$.validator.methods.email = function (value, element) {
	return this.optional(element) || /^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$/.test(value);
};

$.validator.addMethod("phoneSG", function (phone_number, element) {
	phone_number = phone_number.replace(/\s+/g, "");
	return this.optional(element) || phone_number.length == 8; //&& phone_number.match(/[6|8|9]\d{4}$/);
}, "Please specify a valid phone number");

$.validator.addMethod("imageDimension", function (value, element, param) {

	if (this.optional(element)) {
		return true;
	}

	var noOfFiles = element.files.length;
	for (var i; i < noOfFiles; i++) {

		var reader = new FileReader();
		//Read the contents of Image File.
		reader.readAsDataURL(fileUpload.files[0]);
		reader.onload = function (e) {
			var image = new Image();
			image.src = e.target.result;
			image.onload = function () {
				var height = this.height;
				var width = this.width;
				if (this.height != param.height || this.width != param.width) {
					return false;
				}
			};
		}
	}
	return true;
}, "Please select file with valid dimension");

$.validator.setDefaults({
	errorPlacement: function (error, element) {
		$("span[data-valmsg-for='" + $(element).attr("name") + "']").html($(error));
	}
});

//// Custom Email validation Rule
//$.validator.methods.password = function (value, element) {
//    return this.optional(element) || /^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.{8,})/.test(value);
//};

function initAlphaNum() {

	// Alpha Numeric Validation
	$(".alphanumFields").alphanum({
		allowSpace: false
	});

	// Alpha Numeric Validation
	$(".alphaFields").alphanum({
		allowSpace: true,
		allowNumeric: false,
		disallow: '!@#$%^&*()+=[]\\\';,/{}|":<>?~`.- _'
	});

	$(".alphanumSpecialFields").alphanum({
		allowSpace: false,
		allow: '!@#$%^&*()_'
	});


	$(".numFields").numeric({
		allowMinus: false,
		allowThouSep: false
	});

	$(".percentage").numeric({
		allowMinus: false,
		allowThouSep: false,
		maxDecimalPlaces: 2,
		maxPreDecimalPlaces: 3,
		max: 100
	});

}

function initRateAndShareFields() {

	$(".rateAndShare").numeric({
		allowMinus: false,
		allowThouSep: false,
		maxDecimalPlaces: 1,
		maxPreDecimalPlaces: 2
	});

}


function initAmountFields() {
	$(".amountFields").numeric({
		allowMinus: false,
		allowThouSep: false,
		maxDecimalPlaces: 2,
		maxPreDecimalPlaces: 16,
		maxDigits: 18
	});

	$(".amountNegativeFields").numeric({
		allowMinus: true,
		allowThouSep: false,
		maxDecimalPlaces: 2,
		maxPreDecimalPlaces: 16,
		maxDigits: 18
	});
}

function resetSelect(selectEle, LabelText) {
	$(selectEle).html($("<option>").text(LabelText).attr({ value: "" }));
}