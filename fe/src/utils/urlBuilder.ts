export const urlBuilder = (
  urlString: string,
  queryObject: Record<string, unknown>,
  noPagination: boolean = false,
) => {
  const pagination = noPagination
    ? []
    : [
        ["pageSize", "1000"],
        ["pageNumber", "0"],
      ];

  const queryParams = new URLSearchParams([
    ...(Object.entries(queryObject)
      .map(([key, value]) => {
        if (value && key !== "id") {
          return [key, `${value}`];
        }
      })
      .filter((x) => x) as string[][]),
    ...pagination,
  ]).toString();

  const idParam = queryObject.id ? `/${queryObject.id}` : "";

  return `${urlString}${idParam}${queryParams ? `?${queryParams}` : ""}/`;
};
