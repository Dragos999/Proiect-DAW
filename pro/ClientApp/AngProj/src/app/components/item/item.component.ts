import { Component,OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ItemService } from '../../services/itemService/item.service';

@Component({
  selector: 'app-item',
  templateUrl: './item.component.html',
  styleUrl: './item.component.css'
})
export class ItemComponent implements OnInit {
  items:any[]=[];
  constructor(private itemService: ItemService, private router:Router) {}

  ngOnInit() {
    this.itemService.getItems().subscribe(data => {
      this.items = data;
    },
    (error)=>{
      console.error('Error',error);
    }
    );
  }
}
