import { Directive, ElementRef } from '@angular/core';
import { HostListener } from '@angular/core';

@Directive({
  selector: '[ShowHide]'
})
export class ShowHideDirective {

  constructor(private elemRef:ElementRef) { }

  @HostListener('click', ['$event.target']) onClick(){
      
      
      let el=document.getElementById('descId');
      if(el){
        if(el?.style.display=='block'){
          el.style.display='none';
        }else{
          el.style.display='block';
        }
      }
      
  }

}
