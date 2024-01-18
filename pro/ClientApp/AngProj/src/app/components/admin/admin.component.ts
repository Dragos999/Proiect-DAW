import { Component } from '@angular/core';
import { ItemService } from '../../services/itemService/item.service';
import { DistributorService } from '../../services/distributorService/distributor.service';
import { FormBuilder, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrl: './admin.component.css'
})
export class AdminComponent {

    addItem!:FormGroup;
    addDistributor!:FormGroup;
    deleteItem!:FormGroup;
    deleteDistributor!:FormGroup;
    message='';
    constructor(private itemService:ItemService,private distributorService:DistributorService,private fb:FormBuilder){}

    ngOnInit(){
      this.addItem=this.fb.group({
        Name:'',
        Price:'',
        Stock:'',
        distributorId:''
      });

      this.deleteItem=this.fb.group({
        Id:''
      });
      
      this.addDistributor=this.fb.group({
        Name:''
      });

      this.deleteDistributor=this.fb.group({
        Id:''
      });
      
    }

    addNewItem():void{
      let distId=this.addItem.get("distributorId")?.value;
      let dId=null;
      if(this.isGuid(distId)){
        dId=distId;
      }
        
      const item={
        Name:this.addItem.get("Name")?.value,
        Price:this.addItem.get("Price")?.value,
        Stock:this.addItem.get("Stock")?.value,
        distributorId:dId
      }
      
      this.itemService.addItem(item).subscribe(
        (data:string)=>{
          console.log(data);
          this.message=data;
        },
        (error)=>{
          console.error;
        }
      )
    }
    deleteItemById():void{
      let itemId=this.deleteItem.get("Id")?.value;
      if(itemId){
        this.itemService.deleteItem(itemId).subscribe(
          (data:string)=>{
            console.log(data);
            this.message=data;
          },
          (error)=>{
            console.error;
          }
        )
      }
    }
    addNewDistributor():void{
      const distributor={
        Name:this.addDistributor.get("Name")?.value
      }
      this.distributorService.addDistributor(distributor).subscribe(
        (data:string)=>{
          console.log(data);
          this.message=data;
        },
        (error)=>{
          console.error;
        }
      )
    }
    deleteDistributorById():void{
      let distributorId=this.deleteDistributor.get("Id")?.value;
      this.distributorService.deleteDistributor(distributorId).subscribe(
        (data:string)=>{
          console.log(data);
          this.message=data;
        },
        (error)=>{
          console.error;
        }
      )
    }
    private isGuid(guidToCheck:string): boolean {

      const guidRegex = /^[0-9a-fA-F]{8}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{12}$/;
  
      return guidRegex.test(guidToCheck);
    }
}
