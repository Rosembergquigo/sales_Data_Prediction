import { Component, OnInit } from '@angular/core';
import { SalesService } from '../../services/sales.service';

@Component({
  selector: 'app-modal',
  standalone: true,
  imports: [],
  templateUrl: './modal.component.html',
  styleUrl: './modal.component.css'
})
export class ModalComponent implements OnInit{
constructor(public salesService:SalesService){}
  ngOnInit(): void {
    this.salesService.getEmployees();
    this.salesService.getShippers();
    this.salesService.getProducts();
  }
}
