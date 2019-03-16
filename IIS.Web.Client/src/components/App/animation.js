export default function spaceStationAnimation() {

    window.requestAnimationFrame = window.requestAnimationFrame || window.mozRequestAnimationFrame || window.webkitRequestAnimationFrame || window.msRequestAnimationFrame;
  
    var earth = document.getElementById("#earthImage");
    var spaceStation = document.getElementById('#spaceStationImage');
    var maxX = earth.clientWidth - spaceStation.offsetWidth;
    var maxY = earth.clientHeight - spaceStation.offsetHeight;
    var fieldHeight = earth.offsetHeight;
    var duration = 100;
    var gridSize = 100;
    
    var start = null;
  
    function step(timestamp)
    {
      var progress, x, y;
      if(start === null) {
        start = timestamp;
      }
  
      progress = (timestamp - start) / duration / 1000; 
  
      x = (fieldHeight/100) * 0.1 * Math.sin(progress * 2 * Math.PI); 
      y = (fieldHeight/100) * 0.5 * Math.cos(progress * 2 * Math.PI); 
      
      spaceStation.style.left = maxX/2 + (gridSize * x) + "px";
      spaceStation.style.bottom = maxY/2 + (gridSize * y) + "px";
      
      if(progress <= 0.5) {
        spaceStation.style.animation = 'fadeInFromNone 0.5s ease-out'
        spaceStation.style.opacity = 1} else {
            spaceStation.style.animation = "fadeOutFromNone 0.5s ease-out"
            spaceStation.style.opacity = 0.2}
  
      if(progress >= 1) start = null;
      requestAnimationFrame(step);
    }
  
    requestAnimationFrame(step);
  
  };