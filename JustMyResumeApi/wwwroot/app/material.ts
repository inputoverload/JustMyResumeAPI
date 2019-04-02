import { MatExpansionModule, MatCard, MatCardModule, MatTable, MatTableModule, MatTabsModule, MatListModule,
        MatSidenavModule } from '@angular/material';
import {NgModule} from '@angular/core';

@NgModule({
  imports: [ 
    MatExpansionModule,
    MatCardModule,
    MatTableModule,
    MatTabsModule, 
    MatListModule,
    MatSidenavModule
  ],
  exports: [
    MatExpansionModule,
    MatCardModule,
    MatTableModule,
    MatTabsModule, 
    MatListModule,
    MatSidenavModule
  ]
})
export class MaterialModule {}


/**  Copyright 2019 Google Inc. All Rights Reserved.
    Use of this source code is governed by an MIT-style license that
    can be found in the LICENSE file at http://angular.io/license */