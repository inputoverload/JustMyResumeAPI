import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, FormArray } from '@angular/forms';
import { FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-user-editor',
  templateUrl: './user-editor.component.html',
  styleUrls: ['./user-editor.component.css']
})
export class UserEditorComponent implements OnInit {
    userForm = this.fb.group ({
      firstName: ['', Validators.required],
      lastName: [''],
      address: this.fb.group ({
        streetAddress: [''],
        streetAddress2: [''],
        city: [''],
        state: [''],
        zipCode: ['']
      }),
      aliases: this.fb.array ([
        this.fb.control('')
      ])
    });

  get aliases() {
    return this.userForm.get('aliases') as FormArray;
  }

  addAlias() {
    this.aliases.push(this.fb.control(''));
  }

  onSubmit() {
    console.warn(this.userForm.value);
  }

  updateUser() {
    this.userForm.patchValue({
      firstName: 'Nancy',
      address: {
        streetAddress: '123 Drew St.'
      }
    });
  }

  constructor(private fb: FormBuilder) { }

  ngOnInit() {
  }

}
