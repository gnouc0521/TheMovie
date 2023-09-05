<template>
    <div>
        <Modal
         :title="L('CreateNewTypeFilm')"
         :value="value"
         @on-ok="save"
         @on-visible-change="visibleChange"
        >
            <Form ref="typefilmForm"  label-position="top"  :model="typefilm">
                <Tabs value="detail">
                    <TabPane :label="L('TypeFilm')" name="detail">
                        <FormItem :label="L('Thể loại phim')" prop="nameType">
                            <Input v-model="typefilm.nameType" :maxlength="32" :minlength="2"></Input>
                        </FormItem>
                        <FormItem :label="L('Code')" prop="code">
                            <Input v-model="typefilm.code" :maxlength="32" :minlength="2"></Input>
                        </FormItem>
                        <FormItem :label="L('Description')" prop="description">
                            <Input v-model="typefilm.description" :maxlength="1024"></Input>
                        </FormItem>
                      </TabPane>
x                </Tabs>
            </Form>
            <div slot="footer">
                <Button @click="cancel">{{L('Cancel')}}</Button>
                <Button @click="save" type="primary">{{L('OK')}}</Button>
            </div>
        </Modal>
    </div>
</template>
<script lang="ts">
    import { Component, Vue,Inject, Prop,Watch } from 'vue-property-decorator';
    import Util from '../../../lib/util'
    import AbpBase from '../../../lib/abpbase'
    import Role from '@/store/entities/role';
    import TypeFilm from '@/store/entities/typefilm';
    @Component
    export default class CreateRole extends AbpBase{
        @Prop({type:Boolean,default:false}) value:boolean;
        role:Role=new Role();
        typefilm:TypeFilm=new TypeFilm();
        save(){
            (this.$refs.typefilmForm as any).validate(async (valid:boolean)=>{
                if(valid){
                    await this.$store.dispatch({
                        type:'typefilm/create',
                        data:this.typefilm
                    });
                    (this.$refs.typefilmForm as any).resetFields();
                    this.$emit('save-success');
                    this.$emit('input',false);
                }
            })
        }
        cancel(){
            (this.$refs.typefilmForm as any).resetFields();
            this.$emit('input',false);
        }
        visibleChange(value:boolean){
            if(!value){
                this.$emit('input',value);
            }
        }
        roleRule={
            name:[{required: true,message:this.L('FieldIsRequired',undefined,this.L('RoleName')),trigger: 'blur'}],
            displayName:[{required:true,message:this.L('FieldIsRequired',undefined,this.L('DisplayName')),trigger: 'blur'}]
        }
    }
</script>

