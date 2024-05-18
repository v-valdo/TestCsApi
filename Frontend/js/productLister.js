import { $ } from './jQueryish.js';
import { fetchEasy } from './fetchEasy.js';

export async function productLister(onlyProducts = false) {
  let categories = await fetchEasy('/api/categories');
  let products = await fetchEasy('/api/products');

  // added map cat id for pics
  products = products.map(product => {
    let category = categories.find(cat => cat.id === product.categoryId);
    return {
      ...product,
      catName: category.name,
      catId: category.id
    };
  });

  let productsToShow = products.filter(product =>
    product.catName === categoryToShow || !categoryToShow
  );

  let element = onlyProducts ? $('.products')[0] : $('article')[0];
  element.innerHTML = /*html*/`
    ${onlyProducts ? '' : /*html*/`<label>Välj kategori:
      <select id="categories">
        <option value="">Alla</option>
        ${categories.map(cat => /*html*/`<option>${cat.name}</option>`).join('')}
      </select>
    </label>`}
    <div class="products">
      ${productsToShow.map(product => /*html*/`
        <div class="product">
          <div class="image-container" style="background-image:url(/images/categories/${product.catId}.webp)"></div>
          <div class="details">
            <h3 class="name">${product.name}</h3>
            <p class="description">${product.description}</p>
            <p class="price">Pris: ${product.price} kr</p>
          </div>
        </div>`).join('')}
    </div>
  `;
}

let categoryToShow = "";
$('select').change(() => {
  categoryToShow = $('select')[0].value;
  $('.products')[0].innerHTML = '';
  productLister(true);
});
