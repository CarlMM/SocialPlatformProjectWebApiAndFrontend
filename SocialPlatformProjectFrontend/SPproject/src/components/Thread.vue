<template>
    <div>
       <div class="container">
         <div class="subform">
           <div class="subforum-title">
              <h1>General Information</h1>
           </div>
         </div>
         <div class="subforum-row">
              <div class="subforum-icon subforum-column center" > 
                  <i class="fas fa-laptop"></i>
              </div>
              <div class="subforum-description subforum-column">
                  <h1>Descriptiption Title <small>Posted by <a href="">User</a> 15 Jan 2022</small></h1>
                  <p>Description Content This is something about computers so swiggety swooty coming for booty</p>
                  <span>Reply Save Edit</span>
                  
              </div>
              <div class="subforum-stats subforum-column">
                  <small>Posted by <a href="">User</a> 15 Jan 2022</small>
              </div>
         </div>
       </div>
    </div>
</template>

<script>
// import { defineComponent } from '@vue/composition-api'

// export default defineComponent({
//     setup() {
        
//     },
// })
</script>


<style scoped>
   /*Global*/

   *{
     box-sizing:border-box;
   }


  a{
    color: rgb(153, 149, 163);
    font-weight: bolder;
  }

  h1{
    font-size: 16px;
    font-weight: bolder;
    color: white;
  }

  /*Body*/
  .container{
    margin: 20px;
    padding:20px;
  }

  .subforum{
    margin-top: 20px;
  }

  .subforum-title{
    background-color:rgb(139, 139, 139);
    padding: 10px;
    border-radius: 5px;
    margin: 4px;
  }

  .subforum-row{
    display: grid;
    grid-template-columns: 7% 60% 13% 20%;
  }

  .subforum-column{
    border-radius: 5px;
    margin: 4px;
    background-color: rgb(139, 139, 139);
  }

  .center{
    display:flex;
    justify-content: center;
    align-items: center;
  }

  .subforum-icon{
    font-size:30px;
  }
   
</style>
