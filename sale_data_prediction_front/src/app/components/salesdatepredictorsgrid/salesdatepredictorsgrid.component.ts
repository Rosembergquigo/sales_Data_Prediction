import { Component, OnInit } from '@angular/core';
import { CommonModule} from '@angular/common';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule, AbstractControl } from '@angular/forms'; 
import { SalesService } from '../../services/sales.service';
import { getCustomerOrders } from '../../models/getCustomerOrder';
import { salesDatePredictor } from '../../models/salesDatePredictor';
import { createOrder } from '../../models/createOrder';
import { ToastrService } from 'ngx-toastr';


declare var bootstrap: any;
@Component({
  selector: 'app-salesdatepredictorsgrid',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './salesdatepredictorsgrid.component.html',
  styleUrl: './salesdatepredictorsgrid.component.css'
})

export class SalesdatepredictorsgridComponent implements OnInit{
  newOrderForm: FormGroup;
  valCtrAlfanumeric = ['',[Validators.required, Validators.pattern('^[a-zA-Z0-9 ]+$')]];
  valCtrSoloTexto = ['',[Validators.required, Validators.pattern('^[a-zA-Z\\s]+$')]];
  valCtrNumerico = ['',[Validators.required, Validators.pattern('^[0-9]+$')]];
  valCtrEmail = ['',[Validators.required,Validators.email]];
  valCtrSelect = ['', Validators.required];
  valCtrMoneda = ['', [Validators.required, Validators.pattern('^\\d{1,3}(,\\d{3})*(\\.\\d{1,2})?$')]];
  valCtrDate = ['', [Validators.required]];
  itmCustomer: salesDatePredictor = new salesDatePredictor;

  constructor(public salesService: SalesService, private fb:FormBuilder, private toastr: ToastrService ){
    this.newOrderForm = this.fb.group({
      nombre: this.valCtrSoloTexto,
      direccion: this.valCtrAlfanumeric,
      ciudad: this.valCtrSoloTexto,
      pais: this.valCtrSoloTexto,
      fechaOrden: this.valCtrDate,
      fechaReq: this.valCtrDate, 
      fechaEntre: this.valCtrDate,
      valorTotal: this.valCtrNumerico,
      precioUnit: this.valCtrNumerico,
      cantidad: this.valCtrNumerico,
      descuento: this.valCtrNumerico,
      trabajador: this.valCtrSelect,
      transportador: this.valCtrSelect,
      producto: this.valCtrSelect
    })
  }
  selectedItem: getCustomerOrders[] = [];
  openModal(id: number, name: string) {
    console.log(id);
    this.salesService.getCustomerOrders(id);
    this.salesService.customerName = name;
    const modalElement = document.getElementById('ordersModal');
    const modal = new bootstrap.Modal(modalElement);
    modal.show();
  }

  openNewModal(customer: salesDatePredictor){
    console.log(customer.id);
    this.itmCustomer = customer;
    this.salesService.customerName = customer.customerName;
    const modalElement = document.getElementById('newOrdModal');
    const modal = new bootstrap.Modal(modalElement);
    modal.show();
  }

  ngOnInit(): void {
    this.salesService.getSalesDatePredictor();
    this.salesService.getEmployees();
    this.salesService.getShippers();
    this.salesService.getProducts();
  }

  onSubmit(){
    console.log('form values: ', this.newOrderForm.value);
    if (this.newOrderForm.valid) {
      const customer = this.itmCustomer;
      console.log('form: ', this.newOrderForm.value);
      console.log('produc: ', parseInt(this.newOrderForm.value.producto) ,'-',this.newOrderForm.value.producto)
      const createOrd = new createOrder(
        customer,
        parseInt(this.newOrderForm.value.trabajador),
        parseInt(this.newOrderForm.value.producto),
        parseInt(this.newOrderForm.value.transportador),
        this.newOrderForm.value.fechaOrden,
        this.newOrderForm.value.fechaReq,
        this.newOrderForm.value.fechaEntre,
        parseInt(this.newOrderForm.value.valorTotal),
        parseInt(this.newOrderForm.value.precioUnit),
        parseInt(this.newOrderForm.value.cantidad),
        parseInt(this.newOrderForm.value.descuento)
      );
      console.log('Formulario válido:', createOrd);

      this.salesService.createOrder(createOrd).subscribe(data =>{
        this.toastr.success('Orden Creada', 'La orden fue creada Correctamente')
        console.log('guardado Exitosamente');
        this.newOrderForm.reset();
      });

    } else {
      console.log('Formulario inválido');
    }
  }
  
}
