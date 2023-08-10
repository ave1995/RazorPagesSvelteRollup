export let title = "";
export let errorKey = "__error";
export let themeKey = "__theme";
export let cacheVersion = "";
export let urlPrefix = "";
export let errorUrl = "/error";
export let notFoundUrl = "/404";
export let signedUserLinks = [];
export let unsignedUserLinks = [];
export function setTitle(value) {
    title = value;
}
export function setKeys(errorKeyValue, themeKeyValue) {
    errorKeyValue && (errorKey = errorKeyValue);
    themeKeyValue && (themeKey = themeKeyValue);
}
export function setFetchConfig(cacheVersionValue, urlPrefixValue) {
    cacheVersionValue && (cacheVersion = cacheVersionValue);
    urlPrefixValue && (urlPrefix = urlPrefixValue);
}
//export function setUser(value: IUser) {
//    user = value;
//}
export function setHeaderLinks(signedUserLinksValue, unsignedUserLinksValue) {
    signedUserLinks = signedUserLinksValue;
    unsignedUserLinks = unsignedUserLinksValue;
}
export function setCommonUrls(errorUrlValue, notFoundUrlValue) {
    errorUrlValue && (errorUrl = errorUrlValue);
    notFoundUrlValue && (notFoundUrl = notFoundUrlValue);
}
//# sourceMappingURL=config.js.map