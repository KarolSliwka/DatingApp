import { Component, inject, input, output } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { AccountService } from '../_services/account.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-rgister',
  imports: [FormsModule],
  templateUrl: './rgister.component.html',
  styleUrl: './rgister.component.css'
})
export class RgisterComponent {
  private accountService = inject(AccountService);
  private toastr = inject(ToastrService);
  // @Input() usersFromHomeComponent: any; old approach 
  usersFromHomeComponent = input.required<any>();
  // old approach for child to parent
  //@Output() cancelRegister = new EventEmitter();
  cancelRegister = output<boolean>();
  model: any = {}

  register() {
    this.accountService.register(this.model).subscribe({
      next: response => {
        console.log(response);
        this.cancel();
      },
      error: error => this.toastr.error(error.error)
    });
  }

  cancel() {
    this.cancelRegister.emit(false);
  }

  // old approach child to parent communication
  // cancel() {
  //   this.cancelRegister.emit(false);
  // }
}
