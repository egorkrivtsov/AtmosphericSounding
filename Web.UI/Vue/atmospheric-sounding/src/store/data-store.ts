import { Module, VuexModule, Mutation, Action } from 'vuex-module-decorators'
import { nameOfFunction } from '@/common/helpers'
import { getData, getColumns } from '../mocks/data'

export const ModuleName: string = 'data-store'

@Module({ namespaced: true, name: ModuleName })
export default class DataModule extends VuexModule {
    public loaded: boolean = false;

    public loading: boolean = false;

    public columns: string[] = []

    public rowsBuffer: any[] = [];

    public rows: any[] = [];

    @Mutation
    public setColumns (columns: string[]): void { this.columns = columns }

    @Mutation
    public addRow (row: any[]): void { this.rows.push(row) }

    @Mutation
    public setRowsBuffer (rows: any[]): void { this.rowsBuffer = rows }

    @Mutation
    public clear (): void { this.rows = [] }

    @Action({ rawError: true })
    public async loadAll (): Promise<void> {
      this.context.commit(nameOfFunction(this, this.setColumns), getColumns())
      this.context.commit(nameOfFunction(this, this.setRowsBuffer), getData())
      const timeInterval = 100

      const emitValue = () => {
        const i = this.rows.length
        this.context.commit(nameOfFunction(this, this.addRow), this.rowsBuffer[i])

        if (i < 100) {
          setTimeout(() => emitValue(), timeInterval)
        }
      }

      setTimeout(() => { emitValue() }, timeInterval)
    }
}
