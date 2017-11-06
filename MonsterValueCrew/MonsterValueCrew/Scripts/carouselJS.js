// This is the file for controlling the carousel slides from MaterializeJS
// start carrousel
   $('.carousel.carousel-slider').carousel({
      fullWidth: true,
      indicators: false
   });


   // move next carousel
   $('.moveNextCarousel').click(function(e){
      e.preventDefault();
      e.stopPropagation();
      $('.carousel').carousel('next');
   });

   // move prev carousel
   $('.movePrevCarousel').click(function(e){
      e.preventDefault();
      e.stopPropagation();
      $('.carousel').carousel('prev');
   });