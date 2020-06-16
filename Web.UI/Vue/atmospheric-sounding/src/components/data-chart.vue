<template>
  <div>

  </div>
</template>
<script lang="ts">

import Vue from 'vue'
import Component from 'vue-class-component'
// import { Watch } from 'vue-property-decorator'
import { QTable, QPageSticky, QBtn, QFab, TouchPan, QBtnGroup, QSlider } from 'quasar'
import store, { dataStore, DataModuleName } from '@/store'
import { nameOfFunction } from '@/common/helpers'
/*
ReChart
AmChart
ApexChart
*/

@Component({
  name: 'DataChart',
  components: { QTable, QPageSticky, QBtn, QFab, QBtnGroup, QSlider },
  directives: {
    TouchPan
  }
})
export default class DataTable extends Vue {
  public get rows (): any[] { return dataStore.rows }

  public get columns (): any[] { return dataStore.columns }

  public btnScrollTopPosition : number[] = [ 18, 18 ];

  public btnScrollTopDraggable : boolean = false;

  public pagination: any = { rowsPerPage: 0 };

  public intervalValue: number = 2;

  $refs!: {
    table: QTable
  }

  // @Watch('rows')
  // public onChildChanged (newValue: any, oldValue: any) { this.scrollTo('end') }

  public async mounted () {
    store.subscribe((mutation: any, state: any) => {
      if (mutation.type === `${DataModuleName}/${nameOfFunction(dataStore, dataStore.addRow)}`) {
        // this.scrollTo('end')
      }
    })
  }
}

</script>
