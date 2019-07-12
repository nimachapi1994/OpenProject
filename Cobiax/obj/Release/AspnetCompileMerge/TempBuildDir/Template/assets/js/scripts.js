(function ($) {
    "use strict";
	
	jQuery(document).ready(function() {

		//Sticky Header
		$(".fixed-after-scroll").sticky({
            stopSpacing: 0
        });

		//Add Header Background after Scroll
		$(window).on("scroll",function(){
			var pagescroll = $(window).scrollTop();
			if(pagescroll > 100){
				$(".header-area").removeClass("transparent-bg");
			}else{
				$(".header-area").addClass("transparent-bg");
			}
		});
		
		//Search Trigger
		$(".search-trigger i").on("click", function() {
            $(".top-search").addClass("show");
        });
        
        $(".search-close-trigger i").on("click", function() {            
            $(".top-search").removeClass("show");
        });

		// HOME PAGE SLIDER
		$(".slider-area").owlCarousel({
			loop:true,
		    nav:true,
		    navText: ["<i class='fa fa-long-arrow-right'></i>","<i class='fa fa-long-arrow-left'></i>"],
		    items:1,		    
		    dots: true,
		    autoplay:true,
		    autoplayTimeout:3000,
		    mouseDrag: false,
            touchDrag: false,
            rtl: true
		});

		$(".slider-area").on("translate.owl.carousel", function(){
            $(".single-slide h1, .single-slide p").removeClass("animated fadeInUp").css("opacity", "0");
            $(".single-slide h2, .single-slide .ven-btn").removeClass("animated fadeInDown").css("opacity", "0");
        });
        
        $(".slider-area").on("translated.owl.carousel", function(){
            $(".single-slide h1, .single-slide p").addClass("animated fadeInUp").css("opacity", "1");
            $(".single-slide h2, .single-slide .ven-btn").addClass("animated fadeInDown").css("opacity", "0");
        });

		var sliderdot = $(".slider-area .owl-dot");
		sliderdot.each(function () {
			var dotnumber = $(this).index() +1;
			if(dotnumber <10){
				$(this).html('0').append(dotnumber);
			}else{
		  		$(this).html(dotnumber);
			}
		});

		// Counter Up
		$(".count-number").counterUp({
            delay: 10,
            time: 1000
        });

        //Isotop Js
        $(".isotope-mobile-title").on('click', function(){
	      $(this).toggleClass("active").next(".work-filter-btn").slideToggle();
	      return false;
	    });

	    var $grid = $(".work-item-wrapper").isotope({
	      itemSelector: ".single-work-item",
	      percentPosition: true,
		  originLeft: false,
	      masonry: {
	        columnWidth: 1
	      }
	    });        

	    $(".work-filter-btn li").on("click", function() {    
	      if($(this).hasClass("active")) return false;
	      $(".isotope-mobile-title, .work-filter-btn li").removeClass("active");
	      $(this).addClass("active");
	      $(".isotope-mobile-title").text($(this).find(".title-text").text());
	      if($(".isotope-mobile-title").is(":visible")) $(".work-filter-btn").slideUp();
	      var filterValue = $(this).attr("data-filter");
	      $grid.isotope({ filter: filterValue });
	    });

	    // Team Carousel
		$(".team-carousel.team-member-wrapper").owlCarousel({
			loop:true,
			nav:true,
			navText: ["<i class='fa fa-long-arrow-right'></i>","<i class='fa fa-long-arrow-left'></i>"],
		    margin: 30,
		    items:4,		    
		    dots: false,
		    autoplay:true,
			autoplayTimeout:3000,
			rtl: true,
		    responsive:{
		    	0:{
		    		items:1
		    	},
		    	768:{
		    		items:3
		    	},
		    	992:{
		    		items:4
		    	}
		    }
		});

		$(".team-carousel2.team-member-wrapper").owlCarousel({
			loop:true,
			nav:true,
			navText: ["<i class='fa fa-long-arrow-right'></i>","<i class='fa fa-long-arrow-left'></i>"],
		    margin: 30,
		    items:3,		    
		    dots: false,
		    autoplay:true,
			autoplayTimeout:3000,
			rtl: true,
		    responsive:{
		    	0:{
		    		items:1
		    	},
		    	768:{
		    		items:3
		    	}
		    }
		});

		// Testimonial Carousel
		$(".testimonial-wraper").owlCarousel({
			loop:true,
		    nav:true,
		    navText: ["<i class='fa fa-angle-right'></i>","<i class='fa fa-angle-left'></i>"],
		    items:1,		    
		    dots: false,
		    autoplay:true,
			autoplayTimeout:3000,
			rtl: true
		});

		$(".client-testimonial-style-3-wrapper").owlCarousel({
			loop:true,
		    nav:false,
		    items:3,		    
		    dots: true,
		    margin: 30,
		    autoplay:true,
			autoplayTimeout:3000,
			rtl: true,
		    responsive:{
		    	0:{
		    		items:1
		    	},
		    	768:{
		    		items:3
		    	}
		    }
		});

		// Clients Carousel
		$(".client-carousel-wrapper").owlCarousel({
			loop:true,
		    nav:false,
		    items:6,
		    margin: 30,		    
		    dots: false,
		    autoplay:true,
			autoplayTimeout:3000,
			rtl: true,
		    responsive:{
		    	0:{
		    		items:2
		    	},
		    	480:{
		    		items:3
		    	},
		    	768:{
		    		items:6
		    	}
		    }
		});

		//Skill bar
		$(".skillbar").each(function() {
			$(this).appear(function() {
				$(this).find(".count-bar").animate({
					width:$(this).attr("data-percent")
				},3000);
			});
		});

		//Single Page Carousel
		$(".single-item-slider").flexslider({
	        animation: "slide",
	        controlNav: "thumbnails",
	        slideshowSpeed: 3000
		});

		//Load More
		$(".load-more-item").slice(0, 4).show();
        $("#loadMore").on("click", function (e) {
            e.preventDefault();
            $(".load-more-item:hidden").slice(0, 4).slideDown();
            if ($(".load-more-item:hidden").length == 0) {
                $("#loadMore").fadeOut("slow");
            }
        });

        //Mobile Menu
        $(".main-menu").slicknav({
            prependTo: "#mobile-menu-wrap",
            label: '',
			closedSymbol: '&#9664;'
        });

        //Wow
        new WOW().init();

        //Scroll Top
        $.scrollUp({
	        scrollName: "scrollUp",
	        scrollDistance: 1000,
	        scrollFrom: "top",
	        scrollSpeed: 800,
	        scrollText: '',
	        zIndex: 100
	    });
	});

	jQuery(window).load(function (){
        $("#preloader").fadeOut(500);
    });
})(jQuery);