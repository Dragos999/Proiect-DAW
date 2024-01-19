import { Component } from '@angular/core';
import { OrderService } from '../../services/orderService/order.service';
import {  FormBuilder,FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-order',
  templateUrl: './order.component.html',
  styleUrl: './order.component.css'
})
export class OrderComponent {
  constructor(private route:ActivatedRoute,private fb:FormBuilder,private orderService:OrderService,private router:Router){ }
  newOrder!:FormGroup;
  itemId:string='';
  message:string='';
  userId=localStorage.getItem('currentId');
  ordAdress!:string;
  ngOnInit(){
    this.itemId = this.route.snapshot.params['Id'];
    this.newOrder=this.fb.group({
      address:'-'
    })

    this.newOrder.valueChanges.subscribe(console.log)
  }

  placeOrder(){
    
    this.ordAdress = this.newOrder.get('address')?.value;
    if(this.userId){
      this.orderService.addOrder(this.userId,this.itemId,this.ordAdress).subscribe(
        (respone:string)=>{console.log(respone);this.message=respone},
        (error)=>{console.error('Order error:', error);}
      )
    }else{
      console.error;
    }
  }
}
