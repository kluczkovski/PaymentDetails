import { Component, OnInit } from '@angular/core';
import { PaymentDetailService } from 'src/app/shared/payment-detail.service';
import { PaymentDetail } from 'src/app/shared/payment-detail.model';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-payment-detail-list',
  templateUrl: './payment-detail-list.component.html',
  styles: []
})
export class PaymentDetailListComponent implements OnInit {

  constructor(private service: PaymentDetailService,
    private toastr: ToastrService) { }

  ngOnInit() {
    this.service.refreshList();
  }

  populateForm(pd: PaymentDetail) {
    //this.service.formData = pd; -> it is the same obj, when you change the information in the form, 
    //                               the same information have been changed in the list.
    this.service.formData = Object.assign({}, pd);
  }

  onDelete(paymentDetailId) {
    if (confirm("Are you sure to delete this record?")) {
      this.service.deletePaymentDetail(paymentDetailId)
        .subscribe(
          res => {
            this.service.refreshList();
            this.toastr.warning('Deleted successfully', 'PaymentDetail Register')

          },
          err => {
            console.log(err);
          })
    }
  }
}
