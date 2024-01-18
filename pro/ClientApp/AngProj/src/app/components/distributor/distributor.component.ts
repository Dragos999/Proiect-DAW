import { Component, OnInit } from '@angular/core';
import { DistributorService } from '../../services/distributorService/distributor.service';
@Component({
  selector: 'app-distributor',
  templateUrl: './distributor.component.html',
  styleUrl: './distributor.component.css'
})
export class DistributorComponent implements OnInit{
    distributors:any[]=[];
    distOutput:string[]=[];

    constructor(private distributorService: DistributorService) {}

    ngOnInit(){
        this.distributorService.getDistributors().subscribe((data)=>
          {
            this.distributors=data;
            this.iterateDist();
          },
          (error)=>{
            console.error('Error',error);
          })
    }

    iterateDist():void{
      for(const distributor of this.distributors){
        this.distributorService.getDistributorItems(distributor.name).subscribe(
          (data:string)=>{
            this.distOutput.push(data);
          },
          (error)=>{
            console.error('Error',error);
          }
        );
        
      }
    }
}
