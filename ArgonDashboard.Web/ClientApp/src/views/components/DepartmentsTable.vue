<template>
  <div class="card mb-4">
    <div class="card-header pb-0">
      <h6>Departments table</h6>
    </div>
    <div class="card-body px-0 pt-0 pb-2">
      <div class="table-responsive p-0">
        <table class="table align-items-center justify-content-center mb-0">
          <thead>
          <tr>
            <th class="text-uppercase text-secondary text-xxs font-weight-bolder opacity-7 ps-2">ID</th>
            <th class="text-uppercase text-secondary text-xxs font-weight-bolder opacity-7 ps-2">Dept. Name</th>
          </tr>
          </thead>
          <tbody>
          <tr v-for="dept of departments" :key="dept.id">
            <td>
              <p class="text-sm font-weight-bold mb-0">{{ dept.id }}</p>
            </td>
            <td>
              <p class="text-sm font-weight-bold mb-0">{{ dept.name }}</p>
            </td>
          </tr>
          </tbody>
        </table>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "departments-table",
  props: {
    departments: Array
  }
}
</script>
